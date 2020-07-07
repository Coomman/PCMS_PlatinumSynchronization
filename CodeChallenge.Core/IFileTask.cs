using System.IO;

namespace CodeChallenge.Core
{
    public interface IFileTask
    {
        void ExecuteFile(StreamReader sr, StreamWriter sw);
    }
}
