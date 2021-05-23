using CodeChallenge.Core;

namespace Lab3
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteConsoleTask(new BinarySearcher());
            //TaskRunner.ExecuteConsoleTask(new Garland());
            //TaskRunner.ExecuteFileTask(new HeapChecker(), "isheap");
            //TaskRunner.ExecuteFileTask(new HeapSorter(), "sort");
            TaskRunner.ExecuteConsoleTask(new RadixSorter());
        }
    }
}
