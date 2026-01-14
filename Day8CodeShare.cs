
namespace GenericsDemo
{
    
    class Program
    {

        public static void swap(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }

        public static void swap(ref DateTime x,ref DateTime y)
        {
            DateTime temp;
            temp = x;
            x = y;
            y = temp;
        }
        public static void swap(ref string x,ref string y)
        {
            string temp;
            temp = x;
            x = y;
            y = temp;
        }
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now.AddDays(2);
            Console.WriteLine("\nBefore swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");
            swap(ref date1, ref date2);
            Console.WriteLine("\nAfter swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");
            Console.ReadLine();
        }
    }
}
right click on the project and add one file with the name Helper1.cs and write the follwing code insdie it 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
     class Helper1
    {
        public static void swap<T>(ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }

    }
}
now i am editing the code i can comment now as i am using helper1 generic method 

namespace GenericsDemo
{
    
    class Program
    {

        //public static void swap(ref int x, ref int y)
        //{
        //    int temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}

        //public static void swap(ref DateTime x, ref DateTime y)
        //{
        //    DateTime temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}
        //public static void swap(ref string x, ref string y)
        //{
        //    string temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}
      static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now.AddDays(2);
            Console.WriteLine("\nBefore swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");
          //  swap(ref date1, ref date2);
            Helper1.swap<DateTime>(ref date1, ref date2);
            Console.WriteLine("\nAfter swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");

            int a = 10, b = 20;
            Console.WriteLine("\nBefore swapping");
            Console.WriteLine($"a:{a} \nb:{b}");
            Helper1.swap<int>(ref a, ref b);
            Console.WriteLine("\nAfter swapping");
            Console.WriteLine($"a:{a} \nb:{b}");
            Console.ReadLine();
        }
    }
}


now i am adding another genric method to add any data type numbers of same type

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
     class Helper1
    {
        public static void swap<T>(ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }
        public static T add<T>(T x, T y)
        {
            dynamic a = x;
            dynamic b = y;
            T sum;
            sum = a + b;
            return sum;
        }

    }
}

main method code 
------------------
namespace GenericsDemo
{
    
    class Program
    {

        //public static void swap(ref int x, ref int y)
        //{
        //    int temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}

        //public static void swap(ref DateTime x, ref DateTime y)
        //{
        //    DateTime temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}
        //public static void swap(ref string x, ref string y)
        //{
        //    string temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}
      static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now.AddDays(2);
            Console.WriteLine("\nBefore swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");
          //  swap(ref date1, ref date2);
            Helper1.swap<DateTime>(ref date1, ref date2);
            Console.WriteLine("\nAfter swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");

            int a = 10, b = 20;
            Console.WriteLine("\nBefore swapping");
            Console.WriteLine($"a:{a} \nb:{b}");
            Helper1.swap<int>(ref a, ref b);
            Console.WriteLine("\nAfter swapping");
            Console.WriteLine($"a:{a} \nb:{b}");

            double d1 = 345.67;
            double d2 = 378.89;
            Console.WriteLine($"The double sum are :{Helper1.add(d1, d2)}");
            Console.WriteLine($"The int sum are :{Helper1.add(a, b)}");

            Console.ReadLine();
        }
    }
}

