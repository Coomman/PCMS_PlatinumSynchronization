using CodeChallenge.Core;

namespace Lab7
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFileTask(new BalanceCalculator(), "balance");
            //TaskRunner.ExecuteFileTask(new Rotation(), "rotation");
            //TaskRunner.ExecuteFileTask(new Insertion(), "addition");
            //TaskRunner.ExecuteFileTask(new Deletion(), "deletion");
            TaskRunner.ExecuteFileTask(new AVLChecker(), "avlset");
        }
    }
}
