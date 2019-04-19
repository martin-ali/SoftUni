using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_slicing_file
{
    class SlicingFile
    {
        static void Main()
        {
            Slice("input.mp4", "sliced", 5);

            var files = Directory.GetFiles("sliced").ToList();
            Assemble(files, "assembled");
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            var extension = Path.GetExtension(sourceFile);
            var name = Path.GetFileNameWithoutExtension(sourceFile);
            using (var inputStream = new FileStream($"{sourceFile}", FileMode.Open, FileAccess.Read))
            {
                var filePartSize = (inputStream.Length / parts) + 1;
                for (int part = 1; part <= filePartSize; part++)
                {
                    var buffer = new byte[filePartSize];
                    var readBytesCount = inputStream.Read(buffer, 0, buffer.Length);

                    if (readBytesCount == 0)
                    {
                        break;
                    }

                    if (Directory.Exists(destinationDirectory) == false)
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    var path = Path.Combine(destinationDirectory, $"{name}-{part}{extension}");
                    using (var outputStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        outputStream.Write(buffer, 0, readBytesCount);
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            if (Directory.Exists(destinationDirectory) == false)
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            var extension = Path.GetExtension(files[0]);
            var destinationPath = Path.Combine(destinationDirectory, $"assembled{extension}");
            using (var outputStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                foreach (var file in files)
                {
                    using (var inputStream = new FileStream($"{file}", FileMode.Open, FileAccess.Read))
                    {
                        while (true)
                        {
                            var buffer = new byte[4096];
                            var readBytesCount = inputStream.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            outputStream.Write(buffer, 0, readBytesCount);
                        }
                    }
                }
            }
        }
    }
}