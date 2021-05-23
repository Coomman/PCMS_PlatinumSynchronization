using System;

namespace CodeChallenge.Core
{
    public class ConsoleTask : LabTask
    {
        public ConsoleTask() {}
        
        protected int ReadInt()
        {
            return ReadInt(Console.In);
        }

        protected int[] ReadIntArray()
        {
            return ReadIntArray(Console.In);
        }

        protected string ReadLine()
        {
            return ReadLine(Console.In);
        }

        protected float[] ReadFloatArray()
        {
            return ReadFloatArray(Console.In);
        }

        protected void Write<T>(T value)
        {
            Console.Write(value);
        }

        protected void WriteLine<T>(T value)
        {
            Console.WriteLine(value);
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
