using System;
using System.IO;
using System.Linq;

namespace _07_directory_traversal
{
    class DirectoryTraversal
    {
        static void Main()
        {
            var directory = new DirectoryInfo("files");
            var files = directory.GetFiles();
            var filesGroupedByExtension = files
                                            .ToLookup(file => file.Extension, file => file)
                                            .OrderByDescending(group => group.Count())
                                            .ThenBy(group => group.Key);

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var reportPath = Path.Combine(desktop, "report.txt");

            using (var desktopWriter = new StreamWriter(reportPath))
            {
                foreach (var extension in filesGroupedByExtension)
                {
                    desktopWriter.WriteLine(extension.Key);

                    foreach (var file in extension.OrderBy(file => file.Length))
                    {
                        var fileLengthInKB = file.Length / 1024D;
                        desktopWriter.WriteLine($"--{file.Name} - {fileLengthInKB:0.000}KB");
                    }
                }
            }
        }
    }
}
