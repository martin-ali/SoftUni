using System;
using System.IO;
using System.IO.Compression;

namespace _06_zip_and_extract
{
    class ZipAndExtract
    {
        static void Main()
        {
            File.Delete("./archive/result.zip");
            File.Delete("./extracted/copyMe.png");

            var dataPath = "./data";
            var zipPath = "./archive/result.zip";
            var extractionPath = "./extracted";

            ZipFile.CreateFromDirectory(dataPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractionPath);
        }
    }
}
