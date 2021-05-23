using CodeChallenge.Core;

namespace Lab4
{
    internal class EntryPoint
    {
        private static void Main()
        {
            TaskRunner.ExecuteFileTask(new StackChecker(), "stack");
            TaskRunner.ExecuteFileTask(new QueueChecker(), "queue");
            TaskRunner.ExecuteFileTask(new BracketsController(), "brackets");
            TaskRunner.ExecuteFileTask(new PolishNotationController(), "postfix");
            TaskRunner.ExecuteConsoleTask(new PriorityQueueChecker());
        }
    }
}
