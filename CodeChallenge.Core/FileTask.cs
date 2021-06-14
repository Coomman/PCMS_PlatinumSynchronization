using System.IO;

namespace CodeChallenge.Core
{
    public abstract class FileTask : LabTask
    {
        protected bool EndOfStream()
        {
            return ((StreamReader) TextReader).EndOfStream;
        }

        public abstract override void Execute();
    }
}
