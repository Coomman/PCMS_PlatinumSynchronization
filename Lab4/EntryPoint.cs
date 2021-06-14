using static CodeChallenge.Core.TaskRunner;

namespace Lab4
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //ExecuteFileTask<StackChecker>("stack");
            //ExecuteFileTask<QueueChecker>("queue");
            //ExecuteFileTask<BracketsController>("brackets");
            //ExecuteFileTask<PolishNotationController>("postfix");
            ExecuteConsoleTask<PriorityQueueChecker>();
        }
    }
}
