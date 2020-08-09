using System.IO;

namespace CodeChallenge.Core
{
    public static class TaskRunner
    {
        public static void ExecuteFile(IFileTask task, string fileName = null)
        {
            string inputFileName = fileName is null ? "input.txt" : $"{fileName}.in";
            string outputFileName = fileName is null ? "output.txt" : $"{fileName}.out";

            using (var sr = new StreamReader(inputFileName))
            using (var sw = new StreamWriter(outputFileName))
                task.ExecuteFile(sr, sw);
        }

        public static void ExecuteConsole(IConsoleTask task)
        {
            task.ExecuteConsole();
        }
    }
}
