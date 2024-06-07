using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Benchmark.Services;

namespace FileTriSortBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\files";
            string csvFilePath = @"results.csv"; // the file is in the \bin\Debug\net8.0

            List<string> filePaths = new List<string>();

            
            foreach (string file in Directory.EnumerateFiles(basePath, "*.txt"))
            {
                filePaths.Add(file);
            }

            
            using (StreamWriter sw = new StreamWriter(csvFilePath, false))
            {
                sw.WriteLine("File, Selection sort, Bubble sort, Insert sort, Quicksort");
            }

            Algo sort = new Algo();

            ValideTheSort valideTheSort = new ValideTheSort();

            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                List<string> lines = File.ReadAllLines(filePath).ToList();
                List<string> sortedLines = new List<string>();

                Stopwatch stopwatch = new Stopwatch();

                
                stopwatch.Start();
                sortedLines = sort.SelectionSort(lines);
                stopwatch.Stop();
                double SelectionSortWatch = stopwatch.Elapsed.TotalMilliseconds;


                stopwatch.Start();
                sortedLines = sort.BubbleSort(lines);
                stopwatch.Stop();
                double BubbleSortWatch = stopwatch.Elapsed.TotalMilliseconds;


                stopwatch.Start();
                sortedLines = sort.InsertionSort(lines);
                stopwatch.Stop();
                double InsertionSortWatch = stopwatch.Elapsed.TotalMilliseconds;


                stopwatch.Start();
                sortedLines = sort.QuickSort(lines);
                stopwatch.Stop();
                double QuickSortWatch = stopwatch.Elapsed.TotalMilliseconds;

                valideTheSort.WriteToCSV(csvFilePath, fileName, SelectionSortWatch, BubbleSortWatch, InsertionSortWatch, QuickSortWatch);

                string sortedLinesHash = valideTheSort.GetMD5(string.Join(Environment.NewLine, sortedLines));
                if (sortedLinesHash != fileName)
                {
                    Console.WriteLine($"Sort error for file => {filePath}");
                }
            }

            Console.WriteLine("All files have been sorted and the results have been written to the results.csv file");
        }
    }
}