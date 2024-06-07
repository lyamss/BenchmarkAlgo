namespace Benchmark.Interfaces
{
    public interface IAlgo
    {
        List<string> SelectionSort(List<string> list);
        List<string> BubbleSort(List<string> list);
        List<string> InsertionSort(List<string> list);
        List<string> QuickSort(List<string> list);
    }
}