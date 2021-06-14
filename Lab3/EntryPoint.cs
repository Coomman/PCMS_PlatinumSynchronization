using static CodeChallenge.Core.TaskRunner;

namespace Lab3
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //ExecuteConsoleTask<BinarySearcher>();
            //ExecuteConsoleTask<Garland>();
            //ExecuteFileTask<HeapChecker>("isheap");
            //ExecuteFileTask<HeapSorter>("sort");
            ExecuteConsoleTask<RadixSorter>();
        }
    }
}
