using CodeChallenge.Core;

namespace Lab6
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFile(new HeightCalculator(), "height");
            //TaskRunner.ExecuteFile(new TreeChecker(), "check");
            //TaskRunner.ExecuteFile(new BSTChecker(), "bstsimple");
            TaskRunner.ExecuteConsole(new QuackIDE());
        }
    }
}
