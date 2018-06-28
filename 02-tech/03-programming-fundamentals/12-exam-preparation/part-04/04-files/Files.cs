using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_files
{
    class Files
    {
        static void Main()
        {
            var filesByIdByRoot = new Dictionary<string, HashSet<File>>();
            var directoryCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < directoryCount; i++)
            {
                var path = Console.ReadLine().Split('\\');

                var root = path.First();
                var file = new File(path.Last());
                var id = $"{file.Name}{file.Extension}";

                if (filesByIdByRoot.ContainsKey(root) == false)
                {
                    filesByIdByRoot[root] = new HashSet<File>();
                }

                // Make sure to override in case of old File
                filesByIdByRoot[root].Remove(file);
                filesByIdByRoot[root].Add(file);
            }

            var query = Console.ReadLine().Split(new[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
            var extension = query[0];
            var queryRoot = query[1];

            if (filesByIdByRoot.ContainsKey(queryRoot))
            {
                var occurrences = filesByIdByRoot[queryRoot].Where(f => f.Extension == extension);

                if (occurrences.Count() > 0)
                {
                    var orderedOccurrences = occurrences.OrderByDescending(x => x.Size).ThenBy(x => x.Name);
                    foreach (var file in orderedOccurrences)
                    {
                        Console.WriteLine(file);
                    }

                    return;
                }
            }

            Console.WriteLine("No");
        }

        private static void Print(Dictionary<string, Dictionary<string, File>> filesByIdByRoot)
        {
            foreach (var root in filesByIdByRoot)
            {
                Console.WriteLine($"Root: {root.Key}");
                foreach (var fileById in root.Value)
                {
                    Console.WriteLine($"- ID: {fileById.Key} -> FILE: {fileById.Value}");
                }
            }
        }
    }

    internal class File
    {
        public File(string fileRawData)
        {
            // No idea why it throws in Judge
            try
            {
                var fileInfo = Regex.Match(fileRawData, @"(.*)\.(.*);(\d*)");

                var name = fileInfo.Groups[1].Value;
                var extension = fileInfo.Groups[2].Value;
                var size = long.Parse(fileInfo.Groups[3].Value);

                this.Name = name;
                this.Extension = extension;
                this.Size = size;
            }
            catch
            {

            }
        }

        public string Name { get; set; }

        public string Extension { get; set; }

        public long Size { get; set; }

        public override string ToString()
        {
            return $"{this.Name}.{this.Extension} - {this.Size} KB";
        }

        public override int GetHashCode()
        {
            var item = this.Name + this.Extension;

            return item.GetHashCode();
        }

        public override bool Equals(object other)
        {
            var otherFile = (File)other;

            return (otherFile.Name == this.Name) && (otherFile.Extension == this.Extension);
        }
    }
}
/*

5
Windows\Temp\win.exe;5423
Games\Wow\wow.exe;1024
Games\Wow\patcher.cs;65212
Games\Pirates\Start\keygen.exe;1024
Games\Pirates\Start\keygen.exe;240
exe in Games

 */
