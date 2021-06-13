using CodeChallenge.Core;

namespace Lab9
{
    internal class EntryPoint
    {
        private static void Main()
        {
            TaskRunner.ExecuteConsoleTask(new TopologicalSorter());
        }
    }
}
