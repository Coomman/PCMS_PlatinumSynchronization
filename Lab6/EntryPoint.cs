using static CodeChallenge.Core.TaskRunner;

namespace Lab6
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //ExecuteFileTask<HeightCalculator>("height");
            //ExecuteFileTask<TreeChecker>("check");
            //ExecuteFileTask<BSTChecker>("bstsimple");
            ExecuteConsoleTask<QuackIDE>();
        }
    }
}
