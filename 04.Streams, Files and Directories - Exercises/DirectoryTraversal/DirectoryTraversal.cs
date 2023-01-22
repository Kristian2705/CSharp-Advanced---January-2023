namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security;
    using static System.Net.WebRequestMethods;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            return string.Join(" ", files);
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string[] files = textContent
                .Split(" ");
            Dictionary<string, List<string>> extensionOccurences = new Dictionary<string, List<string>>();
            FileInfo[] fileInfos = new FileInfo[files.Length];
            for(int i = 0; i < files.Length; i++)
            {
                FileInfo currFile = new FileInfo(files[i]);
                fileInfos[i] = currFile;
            }
            foreach(var fileInfo in fileInfos.OrderBy(x => x.Length))
            {
                if (!extensionOccurences.ContainsKey(fileInfo.Extension))
                {
                    extensionOccurences[fileInfo.Extension] = new List<string>();
                }
                extensionOccurences[fileInfo.Extension].Add($"{fileInfo.Name}{fileInfo.Extension} - {fileInfo.Length / 1024.0:F3}kb");
            }
            extensionOccurences = extensionOccurences.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            using(StreamWriter writer = new StreamWriter(@"C:\Users\Public\Desktop\report.txt"))
            {
                foreach (var ext in extensionOccurences)
                {
                    writer.WriteLine(ext.Key);
                    foreach(var file in ext.Value)
                    {
                        writer.WriteLine($"--{file}");
                    }
                }
            }
        }
    }
}
