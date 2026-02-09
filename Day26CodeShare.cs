
using System.Diagnostics;
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
        public static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            return Enumerable.Range(1,size).OrderBy(x => rand.Next()).ToArray();
        }
        public static void CompareSortingEfficiency(int[] data )
        {
            var bublesort =(int[])data.Clone();
            var seelctionsort =(int[]) data.Clone();
            var insertsort =(int[]) data.Clone();
            var stopwatch = Stopwatch.StartNew();
            BubbleSort(bublesort);
            stopwatch.Stop();
            Console.WriteLine($"Bubble sort Time :{stopwatch.ElapsedMilliseconds} ");

            stopwatch = Stopwatch.StartNew();
            SelectionSort(seelctionsort);
            stopwatch.Stop();
            Console.WriteLine($"selection  sort Time :{stopwatch.ElapsedMilliseconds} ");

            stopwatch = Stopwatch.StartNew();
            InsertionSort(insertsort);
            stopwatch.Stop();
            Console.WriteLine($"Insertion  sort Time :{stopwatch.ElapsedMilliseconds} ");

        }
        static void Main(string[] args)
        {
            int[] data2 = GenerateRandomArray(10000);
            Console.WriteLine("Efficiency Comparison of Sorting Algorithms on 10,000 Random Integers\n");
            //for(int i=0;i<data2.Length;i++)
            //{
            //    Console.WriteLine($"{data2[i]}");
            //}

            CompareSortingEfficiency(data2);
            Console.ReadLine();

        }
    }
}
Iterative and recursive 
--------------------------
namespace iterative_and_recursiesemo
{
    internal class Program
    {
        public void calculateIterative(int n)
        {
            while(n>0)
            {
                int k = n * n;
                Console.WriteLine(k);
                n = n - 1;
            }
        }
        public void calculateRecursive(int n)
        {
            if(n>0)
            {
                int k = n * n;
                Console.WriteLine(k);
                calculateRecursive(n-1);
            }
        }
        public void calculateRecursiveHead(int n)
        {
            if (n > 0)
            {
                calculateRecursiveHead(n - 1);
                int k = n * n;
                Console.WriteLine(k);
                
            }
        }

        public void calculateRecursiveTree(int n)
        {
            if (n > 0)
            {
                calculateRecursiveTree(n - 1);
                int k = n * n;
                Console.WriteLine(k);
                calculateRecursiveTree(n - 1);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
                Console.WriteLine("Iterative approach:");
                p.calculateIterative(5);
                Console.WriteLine("Recursive approach:");
                p.calculateRecursive(5);
                Console.WriteLine("Recursive head approach:");
                p.calculateRecursiveHead(5);

               Console.WriteLine("Recursive tree approach:");
                p.calculateRecursiveTree(5);
            Console.ReadLine();
        }
    }
}
