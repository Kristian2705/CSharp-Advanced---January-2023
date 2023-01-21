namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using(StreamReader reader = new StreamReader(firstInputFilePath))
            {
                List<string> input1 = reader.ReadToEnd()
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    List<string> input2 = reader2.ReadToEnd()
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                    using(StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        for (int i = 0; i < Math.Min(input1.Count, input2.Count); i++)
                        {
                            writer.WriteLine(input1[i]);
                            writer.WriteLine(input2[i]);
                        }
                        if(input1.Count > input2.Count)
                        {
                            for (int i = Math.Min(input1.Count, input2.Count); i < Math.Max(input1.Count, input2.Count); i++)
                            {
                                writer.WriteLine(input1[i]);
                            }
                        }
                        else if(input1.Count < input2.Count)
                        {
                            for (int i = Math.Min(input1.Count, input2.Count); i < Math.Max(input1.Count, input2.Count); i++)
                            {
                                writer.WriteLine(input2[i]);
                            }
                        }
                    }
                }
            }
        }
    }
}
