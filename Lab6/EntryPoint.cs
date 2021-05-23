using CodeChallenge.Core;

namespace Lab6
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFileTask(new HeightCalculator(), "height");
            //TaskRunner.ExecuteFileTask(new TreeChecker(), "check");
            //TaskRunner.ExecuteFileTask(new BSTChecker(), "bstsimple");
            TaskRunner.ExecuteConsoleTask(new QuackIDE());
        }
    }
}
