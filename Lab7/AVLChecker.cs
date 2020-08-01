using System.IO;
using CodeChallenge.Core;

namespace Lab7
{
    public class AVLChecker : IFileTask
    {
        private readonly AVL _avl = new AVL();

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var query = sr.ReadLine().Split();

                switch (query[0][0])
                {
                    case 'A':
                        _avl.Insert(int.Parse(query[1]));
                        sw.WriteLine(_avl.GetRootBalance());
                        break;
                    case 'D':
                        _avl.Delete(int.Parse(query[1]));
                        sw.WriteLine(_avl.GetRootBalance());
                        break;
                    case 'C':
                        sw.WriteLine(_avl.Find(int.Parse(query[1])) is null ? "N" : "Y");
                        break;
                }
            }
        }
    }
}
