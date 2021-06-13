using System;
using System.IO;

namespace CodeChallenge.Core
{
    public class FileTask : LabTask, IDisposable
    {
        public StreamReader Sr { get; set; }
        public StreamWriter Sw { get; set; }

        protected int ReadInt()
        {
            return ReadInt(Sr);
        }

        protected int[] ReadIntArray()
        {
            return ReadIntArray(Sr);
        }

        protected string ReadLine()
        {
            return ReadLine(Sr);
        }

        protected float[] ReadFloatArray()
        {
            return ReadFloatArray(Sr);
        }

        protected void Write<T>(T value)
        {
            Sw.Write(value);
        }

        protected void WriteLine()
        {
            Sw.WriteLine();
        }

        protected void WriteLine<T>(T value)
        {
            Sw.WriteLine(value);
        }

        public void Dispose()
        {
            Sr?.Dispose();
            Sw?.Dispose();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
