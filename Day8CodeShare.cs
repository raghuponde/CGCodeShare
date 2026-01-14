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
          //  add(10, 20);
            mydelegate1 m1 = add;
            m1(12, 45);
            mydelegate2 m2 = substract;
             Console.WriteLine($"The substraction is :{m2(23, 6)}");
            m2+= multiply;//multi cast delegate same pointer pointing to multiple functions 
            Console.WriteLine($"The multilication is :{m2(23, 6)}");
            mydelegate1 m3 = add;
            m3 += divide;
            m3.Invoke(100, 50);//other way of calling a delgate
            mydelegate2 m4 = substract;
                        m4 += multiply;
            foreach (mydelegate2 del in m4.GetInvocationList())
            {
                Console.WriteLine($"Result :{del(50, 10)}");
            }
			// using for each loop i can print return values also 
            Console.ReadLine();
        }
    }
}



anaonymous execution :
----------------------
A function which will not have any  name is called anomymous function and that function can be executed using delegate
  reference so let us see that one 

namespace anonoumuusingdelegate
{
    internal class Program
    {
        //public static void add(int x, int y)
        //{
        //    Console.WriteLine($"The sum is :{x + y}");
        //}
        //public static int substract(int x, int y)
        //{
        //    return x - y;
        //}
        //public static int multiply(int x, int y)
        //{
        //    return x * y;
        //}
        //public static void divide(int x, int y)
        //{
        //    Console.WriteLine($"The division is :{x / y}");

        //}

        public delegate void mydelegate1(int a, int b);
        public delegate int mydelegate2(int a, int b);
    
        static void Main(string[] args)
        {
            mydelegate1 m1 = delegate (int x, int y)
            {
                Console.WriteLine($"The sum is :{x + y}");
            };
            m1 += delegate (int x, int y)
            {
                Console.WriteLine($"The division is :{x / y}");

            };
            m1(12, 4);
            mydelegate2 m2 = delegate (int x, int y)
            {
                return x - y;
            };
            Console.WriteLine($"subsctraction is :{m2.Invoke(12, 7)}");
            m2 += delegate (int x, int y)
            {
                return x * y;
            };
            Console.WriteLine($"multiplication  is :{m2.Invoke(12, 7)}");
            Console.ReadLine();

        }
    }
}

delegate version 3 with lamda expression:
------------------------------------------
//Lambda expression : 
//-------------------------
//some times u want to execute the function in a single line when 
//	u think that inside that function lot of code is not there then i will
//	make that function run using lambda expression and this is very much used
//			   in MVC programming and linq programming

namespace lambdausingdelegate
{
     class Program
    {
        public static void add(int x, int y)
        {
            Console.WriteLine($"The sum is :{x + y}");
        }
        public static int substract(int x, int y)
        {
            return x - y;
        }
        public static int multiply(int x, int y)
        {
            return x * y;
        }
        public static void divide(int x, int y)
        {
            Console.WriteLine($"The division is :{x / y}");

        }
        public delegate void mydelegate1(int a, int b);
        public delegate int mydelegate2(int a, int b);

        static void Main(string[] args)
        {
            
        }
    }
}
final code using lambda expression 
----------------------------------
namespace lambdausingdelegate
{
     class Program
    {
        //public static void add(int x, int y)
        //{
        //    Console.WriteLine($"The sum is :{x + y}");
        //}
        //public static int substract(int x, int y)
        //{
        //    return x - y;
        //}
        //public static int multiply(int x, int y)
        //{
        //    return x * y;
        //}
        //public static void divide(int x, int y)
        //{
        //    Console.WriteLine($"The division is :{x / y}");

        //}
        public delegate void mydelegate1(int a, int b);
        public delegate int mydelegate2(int a, int b);

        static void Main(string[] args)
        {
            mydelegate1 m1=(x,y)=> Console.WriteLine($"The sum is :{x + y}");
            m1+=(x,y)=> Console.WriteLine($"The division is :{x / y}");
            mydelegate2 m2 = (x, y) => x - y;
            m2 += (x, y) => x * y;
            foreach (mydelegate2 mm in m2.GetInvocationList())
            {
                Console.WriteLine($"Result :{mm(50, 10)}");
            }
            Console.ReadLine();
        }
    }
}
Till Now i was doing console application where no event is there means only functions weere there
to that function i was pointing using deletagte and  i was executng the code in fuction now 
let us create one default event in console and event will now call a delegate and delegate will run to which function it is pointing .

  event -->delegate --->function 
namespace eventdelegatedemoinconsole
{
     class Program
    {
        public Program()
        {
            myevent = new mydelegate1(testfunction);
        }
        public void testfunction()
        {
            Console.WriteLine("Test function called");
        }
        public delegate void mydelegate1();
        public event mydelegate1 myevent;
        static void Main(string[] args)
        {
           Program pp=new Program();
            pp.myevent();
            //above two lines can be wtiteen in a single line like tis 
            new Program().myevent();
            Console.ReadLine();
        }
    }
}

  
In C#, Func, Action, and Predicate are built-in delegates that represent different types of methods. 
  They are commonly used for passing methods as parameters, providing a more functional programming style.

Func: A delegate that can take zero or more input parameters and must return a value.

Syntax: Func<T1, T2, TResult> where T1 and T2 are input types, and TResult is the return type.
Action: A delegate that can take zero or more input parameters but does not return a value.

Syntax: Action<T1, T2> where T1 and T2 are input types.
Predicate: A delegate that takes a single parameter and returns a bool.

Syntax: Predicate<T> where T is the input type.

suppose i am having functions like this in the program 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltdelgatesdemo
{
    internal class Program
    {
        public static void add(int a, float b, decimal k)
        {
            Console.WriteLine($"The sum is:{a + Convert.ToDecimal(b) + k}");
        }

        public static double add(int a, decimal b, double kk)
        {
            return (a + Convert.ToDouble(b) + kk);

        }

        public static bool checklength(string str)
        {
            if (str.Length > 10)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
        }
    }
}

namespace InBuitDelegateDemo
{
    internal class Program
    {
        public static void add(int a, float b, decimal k)
        {
            Console.WriteLine($"The sum is:{a + Convert.ToDecimal(b) + k}");
        }

        public static double add(int a, decimal b, double kk)
        {
            return (a + Convert.ToDouble(b) + kk);

        }

        public static bool checklength(string str)
        {
            if (str.Length > 10)
                return true;
            else
                return false;
        }
        public delegate void mydelegate1(int a, float b, decimal k);
        public delegate double mydelegate2(int a, decimal b, double kk);
        public delegate bool mydelegate3(string str);
        static void Main(string[] args)
        {
            mydelegate1 m1 = add;
            m1(12, 56F, 456.67M);
            mydelegate2 m2 = add;
            double result = m2(12, 45.67M, 78.9);
            Console.WriteLine(result);
            mydelegate3 m3 = checklength;
            bool res = m3("HelloWorld!");
            Console.WriteLine($"The string length is having more than 10 chars:{res}");
            Console.ReadLine();
        }
    }
}
so above code is like this now same program i will change like this using in built deleagtes 
finall code 

namespace InBuitDelegateDemo
{
    internal class Program
    {
        public static void add(int a, float b, decimal k)
        {
            Console.WriteLine($"The sum is:{a + Convert.ToDecimal(b) + k}");
        }

        public static double add(int a, decimal b, double kk)
        {
            return (a + Convert.ToDouble(b) + kk);

        }

        public static bool checklength(string str)
        {
            if (str.Length > 10)
                return true;
            else
                return false;
        }
        //public delegate void mydelegate1(int a, float b, decimal k);
        //public delegate double mydelegate2(int a, decimal b, double kk);
        //public delegate bool mydelegate3(string str);
        static void Main(string[] args)
        {
            Action<int,float,decimal> m1 = add;
            m1(12, 56F, 456.67M);
            Func<int,decimal,double,double> m2 = add;
            double result = m2(12, 45.67M, 78.9);
            Console.WriteLine(result);
            Predicate<string> m3 = checklength;
            bool res = m3("HelloWorld!");
            Console.WriteLine($"The string length is having more than 10 chars:{res}");
            Console.ReadLine();
        }
    }
}
construcntor demo
-----------------

namespace constructordemo
{
    class Vehicle
    {
        public string Make { set; get; }
        public string Model { set; get; }

        public Vehicle()
        {
            Console.WriteLine("Default Constructor called");
        }
        public Vehicle(string make1,string model1)
        {
                this.Make = make1;
            this.Model = model1;
            Console.WriteLine($"Parameterized Constructor called: Make={Make}, Model={Model}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
