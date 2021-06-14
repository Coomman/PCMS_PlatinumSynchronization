using System;
using System.IO;
using System.Threading;

namespace CodeChallenge.Core
{
    public static class TaskRunner
    {
        public static void ExecuteConsoleTask<T>() where T : ConsoleTask
        {
            using (var task = Activator.CreateInstance<T>())
            {
                task.TextReader = Console.In;
                task.TextWriter = Console.Out;

                RunTask(task);
            }
        }

        public static void ExecuteFileTask<T>(string fileName = null) where T : FileTask
        {
            string inputFileName = fileName is null ? "input.txt" : $"{fileName}.in";
            string outputFileName = fileName is null ? "output.txt" : $"{fileName}.out";

            var sr = new StreamReader(inputFileName);
            var sw = new StreamWriter(outputFileName);

            using (var task = Activator.CreateInstance<T>())
            {
                task.TextReader = sr;
                task.TextWriter = sw;

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
