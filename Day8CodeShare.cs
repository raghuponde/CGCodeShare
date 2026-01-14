Generics:
---------

Generics means code reuse dont write the same code repeteadely put the code inside a method and call the method repeatedly which is called as generic method 

and in the same manner dont write the same method repeteadly put the methods inside a class and use the class repeteadly called as Generic class 

when you are using generics type safety is ensured 



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

Now i want to take ths generic metod at the class level now add another clas Helper2 in project 

and write the code like this for it

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    internal class Helper2<T>
    {
        public static void swap(ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }
        public static T add(T x, T y)
        {
            dynamic a = x;
            dynamic b = y;
            T sum;
            sum = a + b;
            return sum;
        }

    }
}
now come to main methid let us use some helper2 methods as well 


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
            Console.WriteLine("\nBefore swapping");
            Console.WriteLine($"d1:{d1} \nd2:{d2}");
            Helper2<double>.swap(ref d1, ref d2);
            Console.WriteLine("\nafter swapping");
            Console.WriteLine($"d1:{d1} \nd2:{d2}");
            Console.WriteLine($"The double sum are :{Helper2<double>.add(d1, d2)}");
            Console.WriteLine($"The int sum are :{Helper2<int>.add(a, b)}");

            Console.ReadLine();
        }
    }
}


Delegates and Events :
----------------------
delegates are function pointers .delegate means getting work done .

when event is raised its corresponding delegate is called and that delegate will call the function .

delgate will have same return type and parameters of that function 

event --->delegate --->function 


public void add(int x, int y) is function 

syntax:
-------
public delegate retuntypeoffunction delegatename (parameters in function) 

public delegate void mydelegate(int x, int y) is the delegate for function add 


here name of delegate is mydelegate and it is having same return type of function add 
and same parameters .



Delegates are function pointers and delegate means getting work done (just telling meaning) 

when ever event is raised event means any event like button click event etc and that event will call its corresponding delegate and
that delegate will call the function 

in windows application for every event like mouse move event ,button click event there is a corresponding delegate in
built provided but in console application there are no events only functions will be there and i will write delegate to the functions 

let us see the in built delegate in windows application 

this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
			// 


so here above EventHandler is the in built delegate over here 

now i will create my own delegates for console application and here events will be not be there okay 
here delegates are reference type they point to some thing and it is totally run time means run time it will 
point to function and execute the function 



event ---->delegate ---->function 


syntax:
-------
public delegate retuntypeoffunction delegatename (parameters in function) 

public delegate void mydelegate(int x, int y) is the delegate for function add 


void add(int x, int y) 
{


}

void substract(int x, int y) 
{


}

In delegates while creating return type of function should match with the function and no of paramters in side the 
function should match with  the numbers of parameters in the function then only it can point to that function 

so same deleagte pointing to multiple functions we call it as multi cast delegate 


namespace delegatedemo1
{


     class Program
    {
        public void add(int x ,int y)
        {
            Console.WriteLine($"The sum is :{x+y}");
        }
        public int substract(int x ,int y)
        {
            return x - y;
        }
        public int multiply(int x ,int y)
        {
            return x * y; 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

final code 
----------
namespace delegatedemo1
{
     class Program
    {
        public static void add(int x ,int y)
        {
            Console.WriteLine($"The sum is :{x+y}");
        }
        public static int substract(int x ,int y)
        {
            return x - y;
        }
        public static  int multiply(int x ,int y)
        {
            return x * y; 
        }
        public static void divide(int x,int y)
        {
            Console.WriteLine($"The division is :{x / y}");

        }
        public delegate void mydelegate1(int a, int b);
        public delegate int mydelegate2(int a, int b);
        static void Main(string[] args)
        {
            mydelegate1 m1 = add;
            m1(12, 45);
            mydelegate2 m2 = substract;
             Console.WriteLine($"The substraction is :{m2(23, 6)}");
            m2+= multiply;//multi cast delegate same pointer pointing to multiple functions 
            Console.WriteLine($"The multilication is :{m2(23, 6)}");
            mydelegate1 m3 = add;
            m3 += divide;
            m3(100, 50);
            Console.ReadLine();
        }
    }
}
