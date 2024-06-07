using Benchmark.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Benchmark.Services
{
    public class ValideTheSort : IValidateTheSort
    {
        public void WriteToCSV(string filePath, string fileName, double selectionSortTime, double bubbleSortTime, double insertionSortTime, double quickSortTime)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{fileName},{selectionSortTime},{bubbleSortTime},{insertionSortTime},{quickSortTime}");
            }
        }


        public string GetMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}