using CodeChallenge.Core;

namespace Lab5
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFile(new SetChecker(), "set");
            //TaskRunner.ExecuteFile(new MapChecker(), "map");
            //TaskRunner.ExecuteFile(new LinkedMapChecker(), "linkedmap");
            TaskRunner.ExecuteFile(new MultiMapChecker(), "multimap");
        }
    }
}
