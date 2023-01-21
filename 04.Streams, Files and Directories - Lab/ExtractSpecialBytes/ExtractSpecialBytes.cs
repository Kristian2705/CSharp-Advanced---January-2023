namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (StreamReader fileStream = new StreamReader(bytesFilePath))
            {
                byte[] buffer = fileStream.ReadToEnd()
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .Select(byte.Parse)
                    .ToArray();
                using (FileStream imageFile = new FileStream(binaryFilePath, FileMode.Open))
                {
                    List<byte> bytes = new List<byte>();
                    byte[] buffer2 = new byte[imageFile.Length];
                    imageFile.Read(buffer2, 0, buffer2.Length);
                    foreach (var b in buffer2)
                    {
                        if (buffer.Contains(b))
                        {
                            bytes.Add(b);
                        }
                    }
                    using (FileStream output = new FileStream(outputPath, FileMode.OpenOrCreate))
                    {
                        output.Write(bytes.ToArray(), 0, bytes.Count);
                    }
                }
            }
        }
    }
}
