using static CodeChallenge.Core.TaskRunner;

namespace Lab5
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //ExecuteFileTask<SetChecker>("set");
            //ExecuteFileTask<MapChecker>("map");
            //ExecuteFileTask<LinkedMapChecker>("linkedmap");
            ExecuteFileTask<MultiMapChecker>("multimap");
        }
    }
}
