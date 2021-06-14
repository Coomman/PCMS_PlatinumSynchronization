using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CodeChallenge.Core
{
    public abstract class LabTask : IDisposable
    {
        public TextReader TextReader { get; set; }
        public TextWriter TextWriter { get; set; }

        protected string ReadLine()
        {
            return TextReader.ReadLine().Trim();
        }

        protected int ReadInt()
        {
            return int.Parse(ReadLine());
        }

        protected int[] ReadIntArray()
        {
            return ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        protected float[] ReadFloatArray()
        {
            return ReadLine()
                .Split()
                .Select(el => float.Parse(el, CultureInfo.InvariantCulture))
                .ToArray();
        }

        protected void Write<T>(T value)
        {
            TextWriter.Write(value);
        }

        protected void WriteLine<T>(T value)
        {
            TextWriter.WriteLine(value);
        }
        protected void WriteLine()
        {
            TextWriter.WriteLine();
        }

        public void Dispose()
        {
            TextWriter?.Dispose();
            TextReader?.Dispose();
        }

        public abstract void Execute();
    }
}
