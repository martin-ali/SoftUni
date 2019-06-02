using System;
using System.IO;

namespace _04_copy_binary_file
{
    class CopyBinaryFile
    {
        static void Main()
        {
            using (var reader = new FileStream("copyMe.png", FileMode.Open))
            using (var writer = new FileStream("copy.png", FileMode.Create))
            {
                while (true)
                {
                    var data = new byte[4096];
                    var bytesRead = reader.Read(data, 0, data.Length);

                    if (bytesRead == 0) break;

                    writer.Write(data, 0, bytesRead);
                }
            }
        }
    }
}
