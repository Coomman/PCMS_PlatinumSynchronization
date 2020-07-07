using System.IO;

namespace Packer
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            var result = new Packer().PackFiles(args);
            File.WriteAllText("Source.cs", result);
        }
    }
}
