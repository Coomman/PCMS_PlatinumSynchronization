using CodeChallenge.Core;

namespace Lab4
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFile(new StackChecker(), "stack");
            //TaskRunner.ExecuteFile(new QueueChecker(), "queue");
            //TaskRunner.ExecuteFile(new BracketsController(), "brackets");
            //TaskRunner.ExecuteFile(new PolishNotationController(), "postfix");
            TaskRunner.ExecuteConsole(new PriorityQueueChecker());
        }
    }
}
