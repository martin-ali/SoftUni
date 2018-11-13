using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08_full_directory_traversal
{
    class FullDirectoryTraversal
    {
        static void Main()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var reportPath = Path.Combine(desktop, "report.txt");

            var reportLines = GetListOfSubdirectoriesAndFiles("files");
            using (var writer = new StreamWriter(reportPath))
            {
                foreach (var line in reportLines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private static IList<string> GetListOfSubdirectoriesAndFiles(string directoryName)
        {
            var directory = new DirectoryInfo(directoryName);
            return GetListOfSubdirectoriesAndFiles(directory, new List<string>());
        }

        private static IList<string> GetListOfSubdirectoriesAndFiles(DirectoryInfo directory, IList<string> subdirectoryAndFileInfoLines, int level = 0)
        {
            var files = directory.GetFiles();
            var filesGroupedByExtension = files
                                            .ToLookup(file => file.Extension, file => file)
                                            .OrderByDescending(group => group.Count())
                                            .ThenBy(group => group.Key);

            var directoryIndentation = new string(' ', level);
            var filesIndentation = new string(' ', level + 1);

            subdirectoryAndFileInfoLines.Add($"{directoryIndentation}[{directory.Name}]");
            foreach (var extension in filesGroupedByExtension)
            {
                subdirectoryAndFileInfoLines.Add($"{directoryIndentation}{extension.Key}");

                foreach (var file in extension.OrderBy(file => file.Length))
                {
                    var fileLengthInKB = file.Length / 1024D;
                    subdirectoryAndFileInfoLines.Add($"{directoryIndentation}--{file.Name} - {fileLengthInKB:0.000}KB");
                }
            }

            foreach (var subdirectory in directory.GetDirectories())
            {
                GetListOfSubdirectoriesAndFiles(subdirectory, subdirectoryAndFileInfoLines, level + 2);
            }

            return subdirectoryAndFileInfoLines;
        }
    }
}
