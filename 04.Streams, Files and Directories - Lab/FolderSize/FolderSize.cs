namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long size = GetFolderSize(folderPath);
            File.WriteAllText(outputFilePath, $"{size / 1024} KB");
        }

        public static long GetFolderSize(string folderPath)
        {
            long size = 0;
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }

            foreach(var dir in Directory.GetDirectories(folderPath))
            {
                size += GetFolderSize(dir);
            }

            return size;
        }
    }
}
