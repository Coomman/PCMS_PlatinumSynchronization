using System.Globalization;
using System.IO;
using System.Linq;

namespace CodeChallenge.Core
{
    public abstract class LabTask
    {
        protected string ReadLine(TextReader reader)
        {
            return reader.ReadLine().Trim();
        }

        protected int ReadInt(TextReader reader)
        {
            return int.Parse(ReadLine(reader));
        }

        protected int[] ReadIntArray(TextReader reader)
        {
            return ReadLine(reader)
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        protected float[] ReadFloatArray(TextReader reader)
        {
            return ReadLine(reader)
                .Split()
                .Select(el => float.Parse(el, CultureInfo.InvariantCulture))
                .ToArray();
        }
    }
}
