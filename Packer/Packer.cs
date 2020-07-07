using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Packer
{
    public class Packer
    {
        private readonly HashSet<string> _usings = new HashSet<string>();
        private readonly StringBuilder _sb = new StringBuilder();

        private readonly string[] _ignoredPatterns = { @"bin\\", @"obj\\", @"bin\/", @"obj\/" };

        public string PackFiles(string[] args)
        {
            new List<(string, string)>
                {
                    ("sourceCode", File.ReadAllText(Path.Combine(args[1], args[2]))),
                    ("entryPoint", File.ReadAllText(Path.Combine(args[1], "EntryPoint.cs"))),
                }
                .Concat(GetFiles(args[0]))
                .ToList()
                .ForEach(AddFile);

            _sb.Insert(0, string.Join("", _usings) + "\r\n");
            return _sb.ToString();
        }

        public string PackProjects(string[] args)
        {
            var dirs = args.Length > 0 ? args : new[] {@"."};

            dirs.SelectMany(GetFiles)
                .OrderByDescending(x => File.GetLastAccessTimeUtc(x.name))
                .ToList()
                .ForEach(AddFile);

            _sb.Insert(0, string.Join("", _usings) + "\r\n");
            return _sb.ToString();
        }

        private IEnumerable<(string name, string src)> GetFiles(string dir)
        {
            return Directory
                .EnumerateFiles(dir, "*.cs", SearchOption.AllDirectories)
                .Where(fn => !_ignoredPatterns.Any(p => Regex.IsMatch(fn, p, RegexOptions.IgnoreCase)))
                .Select(fn => (name: fn, src: File.ReadAllText(fn)));
        }

        private void AddFile((string name, string src) file)
        {
            Console.WriteLine($"use {file.name}");

            var source = file.src;
            const string pattern = @"using [A-Z0-9.]+;\r?\n";

            Regex.Matches(source, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase)
                .Select(m => m.Value)
                .ToList()
                .ForEach(line => _usings.Add(line));

            var sourceWithoutUsings =
                Regex.Replace(source, pattern, "", RegexOptions.Multiline | RegexOptions.IgnoreCase)
                    .Trim();

            _sb.AppendLine(sourceWithoutUsings).AppendLine();
        }
    }
}