using CodeChallenge.Core;

namespace Lab8
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFileTask(new EdgesToMatrix());
            //TaskRunner.ExecuteFileTask(new IndirectCheck());
            //TaskRunner.ExecuteFileTask(new ParallelEdgesCheck());
            //TaskRunner.ExecuteFileTask(new Components(), "components");
            //TaskRunner.ExecuteConsoleTask(new PathFinder());
            TaskRunner.ExecuteFileTask(new LabyrinthExplorer());
        }
    }
}
