namespace Benchmark.Interfaces
{
    public interface IValidateTheSort
    {
        void WriteToCSV(string filePath, string fileName, double selectionSortTime, double bubbleSortTime, double insertionSortTime, double quickSortTime);
        string GetMD5(string input);
    }
}