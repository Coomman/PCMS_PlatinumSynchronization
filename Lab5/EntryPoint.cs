using CodeChallenge.Core;

namespace Lab5
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFileTask(new SetChecker(), "set");
            //TaskRunner.ExecuteFileTask(new MapChecker(), "map");
            //TaskRunner.ExecuteFileTask(new LinkedMapChecker(), "linkedmap");
            TaskRunner.ExecuteFileTask(new MultiMapChecker(), "multimap");
        }
    }
}
