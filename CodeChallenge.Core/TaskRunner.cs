using System.IO;
using System.Threading;

namespace CodeChallenge.Core
{
    public static class TaskRunner
    {
        public static void ExecuteConsoleTask(ConsoleTask task)
        {
            RunTask(task);
        }

        public static void ExecuteFileTask(FileTask task, string fileName = null)
        {
            string inputFileName = fileName is null ? "input.txt" : $"{fileName}.in";
            string outputFileName = fileName is null ? "output.txt" : $"{fileName}.out";

            using (var sr = new StreamReader(inputFileName))
            using (var sw = new StreamWriter(outputFileName))
            {
                task.Sr = sr;
                task.Sw = sw;

                RunTask(task);
            }
        }

        private static void RunTask(LabTask task)
        {
            const int stackSize = 2_100_000_000;
            var thread = new Thread(task.Execute, stackSize);

            thread.Start();
            thread.Join();
        }
    }
}
