using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_directory_traversal
{
    class DirectoryTraversal
    {
        private static readonly string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        private static readonly string reportDirectory = Path.Combine(desktop, "report.txt");

        static void Main()
        {
            var filesByExtension = Directory
                                    .GetFiles(Environment.CurrentDirectory)
                                    .Select(f => new FileInfo(f))
                                    .GroupBy(f => f.Extension)
                                    .OrderByDescending(e => e.Count())
                                    .ThenBy(e => e.Key);

            using (var writer = new StreamWriter(reportDirectory))
            {
                foreach (var extension in filesByExtension)
                {
                    writer.WriteLine(extension.Key);

                    var sortedExtension = extension.OrderBy(f => f.Length).ThenBy(f => f.Name);
                    foreach (var file in sortedExtension)
                    {
                        var fileSizeInKB = (double)file.Length / 1024;

                        writer.WriteLine($"--{file.Name} - {fileSizeInKB:0.000}kb");
                    }
                }
            }
        }
    }
}
