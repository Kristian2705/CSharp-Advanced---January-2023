namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] separators = { " ", ",", ".", "!", "?", "-" };
            Dictionary<string, int> wordOccurences = new Dictionary<string, int>();
            using(StreamReader reader = new StreamReader(wordsFilePath))
            {
                string[] words = reader.ReadToEnd().ToLower()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (!wordOccurences.ContainsKey(word))
                    {
                        wordOccurences[word] = 0;
                    }
                }
                using (StreamReader reader2 = new StreamReader(textFilePath))
                {
                    string[] text = reader2.ReadToEnd().ToLower()
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach(var word in text)
                    {
                        if (wordOccurences.ContainsKey(word))
                        {
                            wordOccurences[word]++;
                        }
                    }
                }
            }
            using(StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach(var word in wordOccurences.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
