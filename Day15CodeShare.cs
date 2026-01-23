version 1 of program 
---------------------
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var subject = Console.ReadLine();

            var regex = new Regex(pattern);
            //once u make the instance of regex u cannot change it means if u want to make
            //use of different pattern another instance of regex has to be created .
            var match= regex.Match(subject);
            //if pattern is found in the subject it returns boolean value as true ..

            Console.WriteLine(match.Success);
            Console.ReadLine();

        }
    }
}


version 2 
------------
    using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var subject = Console.ReadLine();

            var regex = new Regex(pattern);
            //once u make the instance of regex u cannot change it means if u want to make
            //use of different pattern another instance of regex has to be created .
            var match= regex.Match(subject);
            //if pattern is found in the subject it returns boolean value as true ..
            if(match.Success)
            {
                Console.WriteLine($"{match.Success}--@{match.Index}--{match.Length}");
            }
            else
            {
                Console.WriteLine($"{match.Success}");
            }

                Console.ReadLine();

        }
    }
}

Version 3 (Final version ) 
----------------------------
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var subject = Console.ReadLine();

            var regex = new Regex(pattern);
            //once u make the instance of regex u cannot change it means if u want to make
            //use of different pattern another instance of regex has to be created .
            var match= regex.Match(subject);
            //if pattern is found in the subject it returns boolean value as true ..
           while(match.Success)
            {
                Console.WriteLine($"{match.Success}--@{match.Index}--{match.Length}");
                match = match.NextMatch();
            }

                Console.ReadLine();

        }
    }
}


m?n

here it means this ? means 0 or 1 time i will come 

m?n
m mn maaaaan n
True--@2--2
True--@11--1
True--@13--1

first here not matches becuase n also should come 

next if u dont write also mn case it is true 

next for maaaaan n is there but i had already told m can come 0 or 1 time so here also correct and matches

lastly n is there which is same 

Pan card validation 
----------------------
^[A-Z]{5}[0-9]{4}[A-Z]$
Email validation 
--------------
^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$

so refer https://regexhero.net/reference/ for creating pattern ...

C# features from C# 8.0 to C# 12.0 
-------------------------------------
1)Top Level statements

int a=20;
int b = 30;
Console.WriteLine($"The sum is {a + b}");

class Program
{
    public static void Main()
    {

    }
}
//here i am getting error it is assumed tht program class is there and main method so i am getting error 

--next ---

    int a=20;
int b = 30;
Console.WriteLine($"The sum is {a + b}");

//class Program
//{
//    public static void Main()
//    {

//    }
//}

class Program2
{
    public static void Main()
    {
        Console.WriteLine("Hello world");
    }
}

u can write like this but hello world i cannot see 

next
-----
using System;
using System.IO;



//class Program
//{
//    public static void Main()
//    {

//    }
//}

class Program2
{
    public static void Main()
    {
        Console.WriteLine("Hello world");
    }
}

int a = 20;
int b = 30;
Console.WriteLine($"The sum is {a + b}");

i can add namespaces of systen and io but i cannot put top level statements down it should be kept up only as they are top level statement


--next --
now i will add one file of c# class and try to write top level statements there  like ths 

Console.WriteLine("Hello world"); //here it wil give error 

--next---

    I want to use a in main method in another class 

        using System;
using System.IO;

int a = 20;
int b = 30;
Console.WriteLine($"The sum is {a + b}");
hai.Demo obj=new hai.Demo();
obj.Method1(a);

//class Program
//{
//    public static void Main()
//    {

//    }
//}

class Program2
{
    public static void Main()
    {
        Console.WriteLine("Hello world");
    }
}
namespace hai
{
    class Demo
    {
        public void Method1(int a)
        {
            //  Console.WriteLine($"{a}");//i cant use a here in main 
            //method a varible
            Console.WriteLine($"{a}");

        }
    }
}

next-- i waant to print the code of program2 
---------------------------------------------
using System;
using System.IO;

int a = 20;
int b = 30;
Console.WriteLine($"The sum is {a + b}");
hai.Demo obj=new hai.Demo();
obj.Method1(a);
Program2 pp2=new Program2();
Program2.Main();//static to static outside class ....using class name ...

//class Program
//{
//    public static void Main()
//    {

//    }
//}

class Program2
{
    public static void Main()
    {
        Console.WriteLine("Hello world");
    }
}
namespace hai
{
    class Demo
    {
        public void Method1(int a)
        {
            //  Console.WriteLine($"{a}");//i cant use a here in main 
            //method a varible
            Console.WriteLine($"{a}");

        }
    }
}

 2)Local Function 
 ********************
 namespace LocalFunctionsDemo
{
    internal class Program
    {
        public int CaluclateSomething (int a, int b)
        {
            int sum = a + b;
            int difference = a - b;
            return sum * difference;
            int Sum(int x,int y)
            {
                return x + y;
            }
            int Difference(int x,int y)
            {
                return x - y; 
            }
        }
        static void Main(string[] args)
        {
            Program pp=new Program();
            Console.WriteLine($"Result :{pp.CaluclateSomething(6, 4)}");
            Console.ReadLine();
        }
    }
}


