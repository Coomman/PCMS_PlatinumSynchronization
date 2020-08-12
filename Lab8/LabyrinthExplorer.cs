using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

using CodeChallenge.Core;

namespace Lab8
{
    public class Labyrinth
    {
        public enum Move {Left, Up, Right, Down};

        private class Cell : IEnumerable<bool>
        {
            private readonly bool[] _moves;

            public int Y { get; }
            public int X { get; }

            public char Dir;
            public Cell PrevCell;
            public bool NotVisited => PrevCell is null;

            public Cell(bool[] moves, int y, int x)
            {
                _moves = moves;
                Y = y;
                X = x;
            }

            public IEnumerator<bool> GetEnumerator()
            {
                return ((IEnumerable<bool>) _moves).GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private readonly int _height;
        private readonly int _width;

        private readonly Cell[,] _lab;

        private Cell _start;
        private Cell _finish;

        private readonly Dictionary<Move, Func<Cell, Cell>> _getNextCell;
        private readonly Dictionary<Move, char> _getDir;

        private ConcurrentBag<Cell> _currentLayer = new ConcurrentBag<Cell>();
        private ConcurrentBag<Cell> _nextLayer = new ConcurrentBag<Cell>();

        public Labyrinth(IReadOnlyList<char[]> field)
        {
            _height = field.Count;
            _width = field[0].Length;

            _lab = new Cell[_height, _width];

            FillLab(field);

            _getNextCell = new Dictionary<Move, Func<Cell, Cell>>
            {
                [Move.Left] = cur => _lab[cur.Y, cur.X - 1],
                [Move.Up] = cur => _lab[cur.Y - 1, cur.X],
                [Move.Right] = cur => _lab[cur.Y, cur.X + 1],
                [Move.Down] = cur => _lab[cur.Y + 1, cur.X]
            };
            _getDir = new Dictionary<Move, char>()
            {
                [Move.Left] = 'L',
                [Move.Up] = 'U',
                [Move.Right] = 'R',
                [Move.Down] = 'D'
            };
        }
        private void FillLab(IReadOnlyList<char[]> field)
        {
            for (int y = 0; y < _height; y++)
            for (int x = 0; x < _width; x++)
            {
                if(field[y][x] == '#')
                    continue;

                var moves = new bool[4];

                if (x - 1 >= 0 && field[y][x - 1] != '#')
                    moves[(int) Move.Left] = true;
                if (y - 1 >= 0 && field[y - 1][x] != '#')
                    moves[(int) Move.Up] = true;
                if (x + 1 < _width && field[y][x + 1] != '#')
                    moves[(int) Move.Right] = true;
                if (y + 1 < _height && field[y + 1][x] != '#')
                    moves[(int) Move.Down] = true;

                _lab[y, x] = new Cell(moves, y, x);

                if (field[y][x] == 'S')
                    _start = _lab[y, x];
                if (field[y][x] == 'T')
                    _finish = _lab[y, x];
            }

            _start.PrevCell = _start;
        }

        private void BfsRoutine(Cell cur)
        {
            cur
                .IndexesWhere(canMoveThisWay => canMoveThisWay is true)
                .AsParallel()
                .ForAll(dir =>
                {
                    var move = (Move) dir;

                    var nextCell = _getNextCell[move].Invoke(cur);
                    if (nextCell.NotVisited)
                    {
                        nextCell.Dir = _getDir[move];
                        nextCell.PrevCell = cur;
                        
                        _nextLayer.Add(nextCell);
                    }
                });
        }
        public void Bfs()
        {
            _currentLayer.Add(_start);

            while (_currentLayer.Any())
            {
                _currentLayer
                    .AsParallel()
                    .ForAll(BfsRoutine);

                _currentLayer = _nextLayer;
                _nextLayer = new ConcurrentBag<Cell>();

                if (!_finish.NotVisited)
                    return;
            }
        }

        public bool HasNoRoute => _finish.NotVisited;

        public char[] GetBestRoute()
        {
            var path = new Stack<char>();
            for (var cur = _finish; cur != _start; cur = cur.PrevCell)
                path.Push(cur.Dir);

            var route = new char[path.Count];
            for (int i = 0; i < route.Length; i++)
                route[i] = path.Pop();

            return route;
        }
    }

    public class LabyrinthExplorer : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var query = sr.ReadLine().Split();

            var height = int.Parse(query[0]);

            var field = new List<char[]>(height);
            for (int i = 0; i < height; i++)
                field.Add(sr.ReadLine().TrimEnd().ToCharArray());

            var lab = new Labyrinth(field);
            lab.Bfs();

            if (lab.HasNoRoute)
            {
                sw.WriteLine(-1);
                return;
            }

            var route = lab.GetBestRoute();

            sw.WriteLine(route.Length);
            foreach(var ch in route)
                sw.Write(ch);
        }
    }
}
