using static CodeChallenge.Core.TaskRunner;

namespace Lab2
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //ExecuteConsoleTask<Sorter>();
            //ExecuteFileTask<Race>("race");
            //ExecuteFileTask<InversionCounter>("inversions");
            //ExecuteConsoleTask<AntiQuickSorter>();
            ExecuteConsoleTask<KthStat>();
        }
    }
}
