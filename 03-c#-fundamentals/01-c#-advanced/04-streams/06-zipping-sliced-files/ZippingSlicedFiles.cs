using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _06_zipping_sliced_files
{
    class ZippingSlicedFiles
    {
        static void Main()
        {
            SliceAndCompress("input.mp4", "sliced-compressed", 5);

            var files = Directory.GetFiles("sliced-compressed").Where(f => f.EndsWith(".gz")).ToList();
            DecompressAndAssemble(files, "assembled-decompressed");
        }

        private static void SliceAndCompress(string sourceFile, string destinationDirectory, int parts)
        {
            var name = Path.GetFileNameWithoutExtension(sourceFile);
            var extension = Path.GetExtension(sourceFile);
            using (var reader = new FileStream($"{sourceFile}", FileMode.Open, FileAccess.Read))
            {
                var filePartSize = (int)Math.Ceiling(reader.Length / (double)parts);
                for (int part = 1; part <= filePartSize; part++)
                {
                    var buffer = new byte[filePartSize];
                    var readBytesCount = reader.Read(buffer, 0, buffer.Length);

                    if (readBytesCount == 0)
                    {
                        break;
                    }

                    if (Directory.Exists(destinationDirectory) == false)
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    var path = Path.Combine(destinationDirectory, $"{name}-{part}{extension}.gz");
                    using (var outputStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                    using (var compressionStream = new GZipStream(outputStream, CompressionLevel.Optimal))
                    {
                        compressionStream.Write(buffer, 0, readBytesCount);
                    }
                }
            }
        }

        private static void DecompressAndAssemble(List<string> files, string destinationDirectory)
        {
            if (Directory.Exists(destinationDirectory) == false)
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            var extension = Path.GetExtension(files[0].Replace(".gz", ""));
            var destinationPath = Path.Combine(destinationDirectory, $"assembled{extension}");
            using (var writer = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                foreach (var file in files)
                {
                    using (var inputStream = new FileStream($"{file}", FileMode.Open, FileAccess.Read))
                    using (var decompressionStream = new GZipStream(inputStream, CompressionMode.Decompress, false))
                    {
                        while (true)
                        {
                            var buffer = new byte[4096];
                            var readBytesCount = decompressionStream.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, readBytesCount);
                        }
                    }
                }
            }
        }
    }
}
