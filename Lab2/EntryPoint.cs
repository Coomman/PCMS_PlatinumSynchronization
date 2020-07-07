using CodeChallenge.Core;

namespace Lab2
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteConsole(new Sorter<int>());
            //TaskRunner.ExecuteFile(new Race(), "race");
            //TaskRunner.ExecuteFile(new InversionCounter(), "inversions");
            //TaskRunner.ExecuteConsole(new AntiQuickSorter());
            TaskRunner.ExecuteConsole(new KthStat());
        }
    }
}
