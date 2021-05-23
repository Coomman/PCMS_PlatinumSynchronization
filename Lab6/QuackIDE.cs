using System;
using System.Collections.Generic;
using System.IO;
using CodeChallenge.Core;

namespace Lab6
{
    public class QuackInterpreter
    {
        private readonly TextWriter _writer;

        private readonly Queue<ushort> _queue = new Queue<ushort>();
        private readonly ushort[] _registers = new ushort[26];

        private readonly Dictionary<char, Action> _zeroArgCmd;
        private readonly Dictionary<char, Action<string>> _oneArgCmd;

        private readonly List<string> _cmdList = new List<string>();
        private readonly Dictionary<string, int> _labels = new Dictionary<string, int>();

        private int _nextCommand;

        public QuackInterpreter(TextWriter writer)
        {
            _zeroArgCmd = new Dictionary<char, Action>
            {
                ['+'] = Add,
                ['-'] = Subtract,
                ['*'] = Multiply,
                ['/'] = Divide,
                ['%'] = Module,
                ['P'] = PrintFirst,
                ['C'] = CharFirst,
                ['Q'] = Quit
            };

            _oneArgCmd = new Dictionary<char, Action<string>>
            {
                ['>'] = cmd => SetRegister(ParseRegister(cmd[1])),
                ['<'] = cmd => GetRegister(ParseRegister(cmd[1])),
                ['P'] = cmd => PrintRegister(ParseRegister(cmd[1])),
                ['C'] = cmd => CharRegister(ParseRegister(cmd[1])),
                ['J'] = cmd => GoTo(cmd.Substring(1)),
                ['Z'] = cmd => GoToIfZero(ParseRegister(cmd[1]), cmd.Substring(2)),
                ['E'] = cmd => GoToIfEquals(ParseRegister(cmd[1]), ParseRegister(cmd[2]), cmd.Substring(3)),
                ['G'] = cmd => GoToIfGreater(ParseRegister(cmd[1]), ParseRegister(cmd[2]), cmd.Substring(3))
            };

            _writer = writer;
        }

        private ushort Get()
            => _queue.Dequeue();
        private void Put(ushort n)
            => _queue.Enqueue(n);

        private void Add()
        {
            Put((ushort) (Get() + Get()));
        }
        private void Subtract()
        {
            Put((ushort) (Get() - Get()));
        }
        private void Multiply()
        {
            Put((ushort) (Get() * Get()));
        }
        private void Divide()
        {
            ushort x = Get();
            ushort y = Get();

            Put((ushort) (y == 0 ? 0 : x / y));
        }
        private void Module()
        {
            int x = Get();
            int y = Get();

            Put((ushort) (y == 0 ? 0 : x % y));
        }

        private void SetRegister(int regNum)
        {
            _registers[regNum] = Get();
        }
        private void GetRegister(int regNum)
        {
            Put(_registers[regNum]);
        }

        private void PrintFirst()
        {
            _writer.WriteLine(Get());
        }
        private void PrintRegister(int regNum)
        {
            _writer.WriteLine(_registers[regNum]);
        }
        private void CharFirst()
        {
            _writer.Write((char) (Get() % 256));
        }
        private void CharRegister(int regNum)
        {
            _writer.Write((char) (_registers[regNum] % 256));
        }

        private void SetLabel(string label)
        {
            _labels.Add(label, _cmdList.Count);
        }

        private void GoTo(string label)
        {
            _nextCommand = _labels[label];
        }
        private void GoToIfZero(int regNum, string label)
        {
            if (_registers[regNum] == 0)
                GoTo(label);
        }
        private void GoToIfEquals(int first, int second, string label)
        {
            if (_registers[first] == _registers[second])
                GoTo(label);
        }
        private void GoToIfGreater(int first, int second, string label)
        {
            if (_registers[first] > _registers[second])
                GoTo(label);
        }

        private void Quit()
        {
            _nextCommand = _cmdList.Count;
        }

        public void AddCommand(string cmd)
        {
            if (cmd[0] == ':')
                SetLabel(cmd.Substring(1));
            else
                _cmdList.Add(cmd);
        }
        public void Run()
        {
            while (_nextCommand < _cmdList.Count)
                RunCommand(_cmdList[_nextCommand]);
        }

        private void RunCommand(string cmd)
        {
            _nextCommand++;

            if (ushort.TryParse(cmd, out var num))
            {
                Put(num);
                return;
            }

            if (cmd.Length == 1)
            {
                _zeroArgCmd[cmd[0]].Invoke();
                return;
            }

            _oneArgCmd[cmd[0]].Invoke(cmd);
        }
        private static int ParseRegister(char c)
        {
            return c - 97;
        }
    }

    public class QuackIDE : ConsoleTask
    {
        public override void Execute()
        {
            var quack = new QuackInterpreter(Console.Out);

            while (true)
            {
                var query = ReadLine();
                if (query == null)
                    break;

                quack.AddCommand(query);
            }

            quack.Run();
        }
    }
}
