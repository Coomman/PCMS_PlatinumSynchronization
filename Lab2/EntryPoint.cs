using CodeChallenge.Core;

namespace Lab2
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteConsoleTask(new Sorter());
            //TaskRunner.ExecuteFileTask(new Race(), "race");
            //TaskRunner.ExecuteFileTask(new InversionCounter(), "inversions");
            //TaskRunner.ExecuteConsoleTask(new AntiQuickSorter());
            TaskRunner.ExecuteConsoleTask(new KthStat());
        }
    }
}
