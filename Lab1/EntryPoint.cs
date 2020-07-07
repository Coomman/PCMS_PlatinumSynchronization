using CodeChallenge.Core;

namespace Lab1
{
    internal class EntryPoint
    {
        private static void Main()
        {
            TaskRunner.ExecuteFile(new AplusB(), "aplusb");
            //TaskRunner.ExecuteFile(new TaskB(), "aplusbb");
            //TaskRunner.ExecuteFile(new Turtle(), "turtle");
            //TaskRunner.ExecuteFile(new SelectionSorter(), "smallsort");
            //TaskRunner.ExecuteFile(new Sortland(), "sortland");
        }
    }
}
