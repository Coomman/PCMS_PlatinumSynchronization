using System.IO;

namespace CodeChallenge.Core
{
    public static class TaskRunner
    {
        public static void ExecuteFile(IFileTask task, string fileName)
        {
            using (var sr = new StreamReader($"{fileName}.in"))
            using (var sw = new StreamWriter($"{fileName}.out"))
                task.ExecuteFile(sr, sw);
        }

        public static void ExecuteConsole(IConsoleTask task)
        {
            task.ExecuteConsole();
        }
    }
}
