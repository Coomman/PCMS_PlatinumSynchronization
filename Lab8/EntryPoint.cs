using CodeChallenge.Core;

namespace Lab8
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFile(new EdgesToMatrix());
            //TaskRunner.ExecuteFile(new IndirectCheck());
            //TaskRunner.ExecuteFile(new ParallelEdgesCheck());
            //TaskRunner.ExecuteFile(new Components(), "components");
            //TaskRunner.ExecuteConsole(new PathFinder());
            TaskRunner.ExecuteFile(new LabyrinthExplorer());
        }
    }
}
