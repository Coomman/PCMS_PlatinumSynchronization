using static CodeChallenge.Core.TaskRunner;

namespace Lab8
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //ExecuteFileTask<EdgesToMatrix>();
            //ExecuteFileTask<IndirectCheck>();
            //ExecuteFileTask<ParallelEdgesCheck>();
            //ExecuteFileTask<Components>("components");
            //ExecuteConsoleTask<PathFinder>();
            ExecuteFileTask<LabyrinthExplorer>();
        }
    }
}
