using static CodeChallenge.Core.TaskRunner;

namespace Lab7
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //ExecuteFileTask<BalanceCalculator>("balance");
            //ExecuteFileTask<Rotation>("rotation");
            //ExecuteFileTask<Insertion>("addition");
            //ExecuteFileTask<Deletion>("deletion");
            ExecuteFileTask<AVLChecker>("avlset");
        }
    }
}
