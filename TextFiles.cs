using System;
using System.IO;

namespace TextFiles
{
    public class Program
    {

        static void writeToTextFile(string filePath, string[] text)
        {
            //string[] text = { "New line 1", "New line 2", "New line 3", "New line 4", "New line 5" };

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("File path cannot be empty.");
            }
            else if (File.Exists(filePath))
            {
                Console.WriteLine($"The file {filePath} already exists. Do you want to overwrite it? (Y/N)");
                var response = Console.ReadLine();
                if (response.Trim().ToUpper() == "Y")
                {
                    File.AppendAllLines(filePath, text);
                    Console.WriteLine($"Text successfully written to {filePath}");
                }
                else
                {
                    Console.WriteLine("Operation aborted.");
                }
            }
            else
            {
                File.AppendAllLines(filePath, text);
                Console.WriteLine($"Text successfully written to {filePath}");
            }
        }

        static void readAllOddsLines(string filePath)
        {
            string[] text = File.ReadAllLines(filePath);

            for (int lineCount = 0; lineCount < text.Length; lineCount++)
            {
                if (lineCount % 2 == 0)
                {
                    Console.WriteLine(text[lineCount]);
                }
            }
        }

        static void ConcatenateTwoTextFiles(string filePath1, string filePath2)
        {
            string[] textFromFile1 = File.ReadAllLines(filePath1);
            string[] textFromFile2 = File.ReadAllLines(filePath2);

            string[] textFromFiles = textFromFile1.Concat(textFromFile2).ToArray();

            Console.WriteLine("Enter file name where you want to write the text");
            string filePath = Console.ReadLine();
            writeToTextFile(filePath, textFromFiles);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full file 1 path:");
            string filePath1 = Console.ReadLine();

            Console.WriteLine("Enter the full file 2 path:");
            string filePath2 = Console.ReadLine();

            try
            {
                //writeToTextFile(filePath);
                //readAllOddsLines(filePath);
                ConcatenateTwoTextFiles(filePath1, filePath2);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access to the file is unauthorized. Please check file permissions.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified file was not found.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("File path is null or empty.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The specified path is invalid.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file path is in an invalid format.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }
    }
}
