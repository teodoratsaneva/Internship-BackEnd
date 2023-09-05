using System;
using System.IO;

namespace TextFiles
{
    public class Program
    {

        static void WriteToTextFile(string fileName, string[] text)
        {
            //string[] text = { "New line 1", "New line 2", "New line 3", "New line 4", "New line 5" };

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("File path cannot be empty.");
            }
            else if (File.Exists(fileName))
            {
                Console.WriteLine($"The file {fileName} already exists. Do you want to overwrite it? (Y/N)");
                var response = Console.ReadLine();

                if (response.Trim().ToUpper() == "Y")
                {
                    File.AppendAllLines(fileName, text);
                    Console.WriteLine($"Text successfully written to {fileName}");
                }
                else
                {
                    Console.WriteLine("Operation aborted.");
                }
            }
            else
            {
                File.AppendAllLines(fileName, text);
                Console.WriteLine($"Text successfully written to {fileName}");
            }
        }

        static void ReadAllOddsLines(string fileName)
        {
            string[] text = File.ReadAllLines(fileName);

            for (int lineCount = 0; lineCount < text.Length; lineCount++)
            {
                if (lineCount % 2 == 0)
                {
                    Console.WriteLine(text[lineCount]);
                }
            }
        }

        static void ConcatenateTwoTextFiles(string fileName1, string fileName2)
        {
            string[] textFromFile1 = File.ReadAllLines(fileName1);
            string[] textFromFile2 = File.ReadAllLines(fileName2);

            string[] textFromFiles = textFromFile1.Concat(textFromFile2).ToArray();

            Console.WriteLine("Enter file name where you want to write the text");
            string filePath = Console.ReadLine();
            writeToTextFile(filePath, textFromFiles);
        }

        static void ReadTextFromFile(string fileName1, string fileName2)
        {
            using (var reader = new StreamReader(fileName1))
            using (var writer = new StreamWriter(fileName2))
            {
                int lineNumber = 1;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($" line {lineNumber}: {line}");
                    lineNumber++;
                    writer.WriteLine(line);
                }
            }
        }

        static void CompareTwoTextFiles(string fileName1, string fileName2)
        {
            using (StreamReader reader1 = new StreamReader(fileName1))
            using (StreamReader reader2 = new StreamReader(fileName2))
            {
                string line1, line2;
                int lineNumber = 1;

                while ((line1 = reader1.ReadLine()) != null && (line2 = reader2.ReadLine()) != null)
                {
                    if (line1 == line2)
                    {
                        Console.WriteLine($"Line {lineNumber}: {line1}");
                    }

                    lineNumber++;
                }
            }
        }

        static void ReplaceWordInTextFile(string fileName)
        {
            string word = Console.ReadLine();
            string wordToReplace = Console.ReadLine();
            string text = File.ReadAllText(fileName);
            text = text.Replace(word, wordToReplace);
            File.WriteAllText(fileName, text);
        }

        static void DeleteAllOddLinesFromTextFile(string fileName)
        {
            string line;
            int line_number = 0;

            using (StreamReader reader = new StreamReader(fileName))
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        line_number++;

                        if (line_number % 2 == 0)
                        {
                            continue;
                        }

                        writer.WriteLine(line);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full file 1 path:");
            string filePath1 = Console.ReadLine();

            Console.WriteLine("Enter the full file 2 path:");
            string filePath2 = Console.ReadLine();

            try
            {
                DeleteAllOddLinesFromTextFile(filePath1);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }
    }
}
