using CodeChallenge.Core;

namespace Lab7
{
    public class AVLChecker : FileTask
    {
        private readonly AVL _avl = new AVL();

        public override void Execute()
        {
            ReadLine();

            while (!EndOfStream())
            {
                var query = ReadLine().Split();

                switch (query[0][0])
                {
                    case 'A':
                        _avl.Insert(int.Parse(query[1]));
                        WriteLine(_avl.GetRootBalance());
                        break;
                    case 'D':
                        _avl.Delete(int.Parse(query[1]));
                        WriteLine(_avl.GetRootBalance());
                        break;
                    case 'C':
                        WriteLine(_avl.Find(int.Parse(query[1])) is null ? "N" : "Y");
                        break;
                }
            }
        }
    }
}
