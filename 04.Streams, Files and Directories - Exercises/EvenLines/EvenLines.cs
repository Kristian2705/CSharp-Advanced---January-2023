namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int count = 0;
                string initialLine = reader.ReadLine().Replace(',', '@').Replace('.', '@').Replace('!', '@').Replace('?', '@').Replace('-', '@');
                string[] line = initialLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Reverse()
                    .ToArray();
                sb.AppendLine(string.Join(" ", line));
                while (!reader.EndOfStream)
                {
                    count++;
                    if (count % 2 == 0)
                    {
                        initialLine = reader.ReadLine().Replace(',', '@').Replace('.', '@').Replace('!', '@').Replace('?', '@').Replace('-', '@');
                        line = initialLine
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Reverse()
                            .ToArray();
                        sb.AppendLine(string.Join(" ", line));
                    }
                    initialLine = reader.ReadLine();
                }
            }
            return sb.ToString();
        }
    }
}
