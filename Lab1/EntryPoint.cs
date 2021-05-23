using CodeChallenge.Core;

namespace Lab1
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFileTask(new AplusB(), "aplusb");
            //TaskRunner.ExecuteFileTask(new AplusBB(), "aplusbb");
            //TaskRunner.ExecuteFileTask(new Turtle(), "turtle");
            //TaskRunner.ExecuteFileTask(new SelectionSorter(), "smallsort");
            TaskRunner.ExecuteFileTask(new Sortland(), "sortland");
        }
    }
}
