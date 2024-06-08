using Benchmark.Interfaces;

namespace Benchmark.Services
{
    public class Algo : IAlgo
    {
        private static void Swap<T>(List<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }


        public List<string> QuickSort(List<string> list)
        {
            QuickSortHelper(list, 0, list.Count - 1);
            return list;
        }

        private static void QuickSortHelper(List<string> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);
                QuickSortHelper(list, low, pivotIndex - 1);
                QuickSortHelper(list, pivotIndex + 1, high);
            }
        }

         private static int Partition(List<string> list, int low, int high)
         {
             int mid = (low + high) / 2;
             if (string.Compare(list[mid], list[low]) < 0)
             {
                 Swap(list, mid, low);
             }
             if (string.Compare(list[high], list[low]) < 0)
             {
                 Swap(list, high, low);
             }
             if (string.Compare(list[mid], list[high]) < 0)
             {
                 Swap(list, mid, high);
             }
             string pivot = list[high];
             int i = low - 1;
             for (int j = low; j <= high; j++)
             {
                 if (string.Compare(list[j], pivot) < 0)
                 {
                     i++;
                     Swap(list, i, j);
                 }
             }
             Swap(list, i + 1, high);
             return i + 1;
         }


        public List<string> InsertionSort(List<string> list)
        {
            int n = list.Count;
            for (int i = 1; i < n; i++)
            {
                string key = list[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(list[j], key) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = key;
            }
            return list;
        }


        public List<string> BubbleSort(List<string> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(list[j], list[j + 1]) > 0)
                    {
                        Swap(list, j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
            return list;
        }

        public List<string> SelectionSort(List<string> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (string.Compare(list[j], list[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(list, i, minIndex);
                }
            }
            return list;
        }
    }
}