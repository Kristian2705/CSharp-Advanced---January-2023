namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int lineCounter = 0;
            List<string> outputLines = new List<string>();
            foreach (string line in lines)
            {
                lineCounter++;
                int letters = 0;
                int punctuationMarks = 0;
                foreach (var ch in line)
                {
                    if ((ch >= 33 && ch <= 47) || (ch >= 58 && ch <= 64))
                    {
                        punctuationMarks++;
                    }
                    else if ((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122))
                    {
                        letters++;
                    }
                }
                outputLines.Add($"Line {lineCounter}: {line} ({letters})({punctuationMarks})");
            }
            File.WriteAllLines(outputFilePath, outputLines.ToArray());
        }
    }
}
