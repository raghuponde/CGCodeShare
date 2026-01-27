
record record_name(data_type Property1, data_type Property2, …);

-- would be compiled as:

Compiled code of Record

class record_name
{
   public data_type Property1 { get; init; }
   public data_type Property2 { get; init; }
 
   public record_name(data_type Parameter1, data_type Parameter2)
   {
      this.Property1 = Parameter1;
      this.Property2 = Parameter2;
   }
}


Features:

Records are 'immutable' by default.

All the record members become as 'init-only' properties.

Records can also be partially / fully mutable - by adding mutable properties.

Supports value-based equality.

Supports inheritance.

Supports non-destructive mutation using 'with' expression.

  namespace RecordDemo
{

    public record Person(string Name,int Age);
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("John", 20);
            Person p2 = new Person("Scott", 34);
            Console.WriteLine($"{p1.Name}--{p1.Age}");
            Console.WriteLine($"{p2.Name}--{p2.Age}");
//            p1.Name="David"//error
     // only in constructor u can set the values 

            Console.ReadLine();
        }
    }
}

5)Expression bodied methods 
***************************
using System;

namespace ExpressionBodiedDemo
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public string AccountHolder { get; set; }

        // Traditional Constructor
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance >= 0 ? initialBalance : 0;
        }

        // Traditional Destructor/Finalizer
        ~BankAccount()
        {
            Console.WriteLine($"Account {AccountNumber} finalized - logging closure");
        }

        // Traditional Methods
        public bool Deposit(decimal amount) 
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public string GetAccountStatus()
        {
            return Balance > 1000 ? "Premium" : "Standard";
        }

        public decimal CalculateInterestRate()
        {
            return Balance switch
            {
                > 10000 => 0.05m,
                > 5000 => 0.04m,
                _ => 0.02m
            };
        }

        // Traditional Property
        public string Summary => $"Account: {AccountNumber}, Balance: ${Balance:N2}";
    }

    class Program
    {
        static void Main()
        {
            var account = new BankAccount("ACC123", "John Doe", 5000);
            account.Deposit(2500);
            Console.WriteLine(account.Summary);
            Console.WriteLine($"Status: {account.GetAccountStatus()}");
        }
    }
}

Converting into Expression Bodied way 
----------------------------------------
namespace ExpressionBodiedMethodsDemo
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public string AccountHolder { get; set; }

        // Traditional Constructor
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
            => (AccountNumber, AccountHolder, Balance) =
            (accountNumber, accountHolder, initialBalance >= 0 ? initialBalance : 0);

        // Traditional Destructor/Finalizer
        ~BankAccount() => Console.WriteLine($"Account {AccountNumber} finalized - logging closure");

        // Traditional Methods
        public bool Deposit(decimal amount) => (amount > 0) && (Balance+=amount)>0 ? true : false;
        
        public bool Withdraw(decimal amount)=>(amount>0) && (Balance-=amount)>0? true : false;


        public string GetAccountStatus() => Balance > 1000 ? "Premimum" : "Standard";
      
        //public decimal CalculateInterestRate()
        //{
        //    return Balance switch
        //    {
        //        > 10000 => 0.05m,
        //        > 5000 => 0.04m,
        //        _ => 0.02m
        //    };
        //}

        // Traditional Property
        public string Summary => $"Account: {AccountNumber}, Balance: ${Balance:N2}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("ACC123", "John Doe", 5000);
            account.Deposit(2500);
            Console.WriteLine(account.Summary);
            Console.WriteLine($"Status: {account.GetAccountStatus()}");
            Console.ReadLine();
        }
    }
}

Tuples 
---------
when single varibale is storing multiple types then we call it as tuples we can desctruce the tuple variable into my individual variables like this 
namespace TuplesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, int Age, bool isActive) person = ("ravi", 30, true);
            Console.WriteLine($"Name:{person.Name}\n Age :{person.Age}\n" +
                $" Active:{person.isActive}");

            //Console.WriteLine($"Name:{Name}");//error here i have to use tuple name

            // so destructuring the tuple 

            var (name1, age1, isactive1) = person;

            Console.WriteLine($"Name:{name1}\n Age :{age1}\n" +
              $" Active:{isactive1}");
            Console.ReadLine();

        }
    }
}

Pattern matching demo 
---------------------
namespace patternmatchingdemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 85;
            string grade = score switch
            {
                >= 90 => "A 🎉",
                >= 80 => "B 👍",
                >= 70 => "C 😊",
                >= 60 => "D 🙂",
                _ => "F 😞"
            };
            Console.WriteLine($"Score {score}={grade}");
            Console.ReadLine();
        }
    }
}
Pattern matching demo 2 
  ----------------------
using System;

namespace StudentGradeDemo
{
    // Simple class with properties
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public int Marks { get; }
        public string Grade { get; private set; } = "";

        public Student(int id, string name, int marks)
        {
            Id = id;
            Name = name;
            Marks = marks;
        }

        public override string ToString() => $"Student[Id={Id}, {Name}, Marks={Marks}]";
    }

    class Program
    {
        // PATTERN MATCHING METHOD - Main feature demo
        static string GetGrade(Student student) => student.Marks switch
        {
            >= 90 => "A 🎉 Excellent!",
            >= 80 => "B 👍 Very Good!",
            >= 70 => "C 😊 Good",
            >= 60 => "D 🙂 Pass",
            >= 50 => "E 😐 Average",
            _ => "F 😞 Fail - Retake"
        };

        static void Main()
        {
            Console.WriteLine("🎯 Pattern Matching with Classes\n");

            // Create students
            Student[] students = {
                new Student(1, "Alice", 92),
                new Student(2, "Bob", 78), 
                new Student(3, "Charlie", 55),
                new Student(4, "Diana", 45)
            };

            // Process each student using pattern matching
            foreach (Student s in students)
            {
                string grade = GetGrade(s);
                Console.WriteLine($"{s} -> {grade}");
            }
        }
    }
}

implemeted in Console program 
----------------------------
namespace patternmatchingdemo2
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public int Marks { get; }
        public string Grade { get; private set; } = "";

        public Student(int id, string name, int marks)
        {
            Id = id;
            Name = name;
            Marks = marks;
        }

        public override string ToString() => $"Student[Id={Id}, {Name}, Marks={Marks}]";
    }
        internal class Program
    {
        static string GetGrade(Student student) => student.Marks switch
        {
            >= 90 => "A 🎉 Excellent!",
            >= 80 => "B 👍 Very Good!",
            >= 70 => "C 😊 Good",
            >= 60 => "D 🙂 Pass",
            >= 50 => "E 😐 Average",
            _ => "F 😞 Fail - Retake"
        };
        static void Main(string[] args)
        {

            Console.WriteLine("🎯 Pattern Matching with Classes\n");

            // Create students
            Student[] students = {
                new Student(1, "Alice", 92),
                new Student(2, "Bob", 78),
                new Student(3, "Charlie", 55),
                new Student(4, "Diana", 45)
            };
            foreach (Student student in students)
            {
                string Grade = GetGrade(student);
                Console.WriteLine($"{student}-->{Grade}");
            }
           
        }
    }
}

Installing Sql Server 2022 
--------------------------
Tom Install sql server first u have to configure IIS server becasue sql server by default gets installed on IIS server this we have done earlier also if u have not done do it 


Thenn go to this link 
   
https://www.microsoft.com/en-us/download/details.aspx?id=104781

MultiThreading 
----------------

   A thread is the smallest unit of code containing sequence of instructions 
    that gets executed to define a unique flow of control and path of execution
    of a program.
  
   example of multithreaded process is internet explorer.
 
   we generally go for threads when we have to deal large and complex applications.

 * Inside the process there are threads so a process that is made up of one thread is called 
 * single threaded process.
 * A process containg two or more threads in it is called multithreaded process.
 * Example of this is web browser i.e internet explorer so within the web browser
 * u can print the page and scroll also so in one process there are mutiple threads.
 * when we do multithreading time is saved as we simaltaneously execute the application.
 * every program has one thread...u can create more threads if necessary.
 * problem with single threaded application is that possibily lengthy activities must
 * complete before other activities can begin and that may be inportant
 * so user feeels that he has spend lot of time.
 * so he goes for multithreading.
 *A memeory is allocated to processs not for thread.
 * 
 * Multitasking is the ability to execute more than one task at a time.
 * multitasking is of two types:
 * 1.process based multitasking
 * 2.Thread based multitasking
 * 
 * 1 example is dos coommand open and running program in editor.
 * 2.text editor is a single process and in that two threads are running.
 * one is of wrting to file and another s printing.
 * These are light weight process.
 * 
 * four advantages of multithreading:
 * 
 * 1.improved performance.
 * 2.minized system resources because same address space is shared by different threads.
 * 3.simaltanues acces due to  quick contxt switching
 * 4.program structure simplification.beacuse task is shared.
 * 
 * 
 * disadvantages:
 * 
 * 1.race condition leads to corruption of data ...producer and consumer problem example
 * 2.deadlock condition happens when two threads wait for each other to complete thir operation.
 * 3.lock starvation.:execution of thread is postponed due to low priority
 * 
 * 
 * Multithreading is platform dependent or os dependent because each time the order or sequence of
 * output changes.
 * 
 * so implement concurency also we go for threads.
 * human body si also example of concurrency we do breathing,smiling,etc 
 * ada was the first language to implement concurrency.
 * c,c++  are example of single threaded languages it wont support multithreading.
 * 
 * garbage collector  is the lowest  priority thread.
 * 
 * 
 * 
 * 
 * 
 *
