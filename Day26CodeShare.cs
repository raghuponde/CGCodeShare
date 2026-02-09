
using System.Reflection;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TimeComplexity
{

    

    internal class Program
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                // Move elements of arr[0..i-1], that are greater than key, to one position ahead
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minidx = i;
               for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minidx])
                    {
                        minidx = j;
                    }
                }
                //swap the foudn ele with first ele
                int temp = arr[minidx];
                arr[minidx] = arr[i];
                arr[i] = temp;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
