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
