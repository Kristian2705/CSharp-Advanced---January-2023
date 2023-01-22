namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] files = Directory.GetFiles(inputPath);
            if(Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            else
            {
                Directory.CreateDirectory(outputPath);
                foreach(string file in files)
                {
                    Directory.Move(file, outputPath);
                }
            }
        }
    }
}
