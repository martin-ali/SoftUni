using System;
using System.IO;

namespace _04_copy_binary_file
{
    class CopyBinaryFile
    {
        static void Main()
        {
            using (var inputStream = new FileStream("input.png", FileMode.Open, FileAccess.Read))
            {
                using (var outputStream = new FileStream("output.png", FileMode.Create, FileAccess.Write))
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
