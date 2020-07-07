using CodeChallenge.Core;

namespace Lab3
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteConsole(new BinarySearcher());
            //TaskRunner.ExecuteConsole(new Garland());
            //TaskRunner.ExecuteFile(new HeapChecker(), "isheap");
            //TaskRunner.ExecuteFile(new HeapSorter(), "sort");
            TaskRunner.ExecuteConsole(new RadixSorter());
        }
    }
}
