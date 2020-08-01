using CodeChallenge.Core;

namespace Lab7
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFile(new BalanceCalculator(), "balance");
            //TaskRunner.ExecuteFile(new Rotation(), "rotation");
            //TaskRunner.ExecuteFile(new Insertion(), "addition");
            //TaskRunner.ExecuteFile(new Deletion(), "deletion");
            TaskRunner.ExecuteFile(new AVLChecker(), "avlset");
        }
    }
}
