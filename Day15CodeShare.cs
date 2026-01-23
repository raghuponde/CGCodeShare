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






