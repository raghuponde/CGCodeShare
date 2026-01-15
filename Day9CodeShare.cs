
namespace paramsdemo
{
    class Employee
    { 
       //public void tsal(int sal,int bonus,int allowances)
       // {
       //     Console.WriteLine($"Total Salary is:{(sal + bonus + allowances)} " );
       // }

       // public void tsal(int sal, int bonus, int allowances,int hraallowences)
       // {
       //     Console.WriteLine($"Total Salary is:{(sal + bonus + allowances+hraallowences)} ");
       // }

       // public void tsal(int sal, int bonus)
       // {
       //     Console.WriteLine($"Total Salary is:{(sal + bonus) } ");
       // }

        public void tsal(params int[] sal)
        {
            int ts = 0;
            for(int i=0;i<sal.Length;i++)
            {
                ts=ts+sal[i];
            }
            Console.WriteLine($"Total Salary is:{ts} ");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee empobj=new Employee();
            empobj.tsal(50000, 10000, 5000);
            empobj.tsal(50000, 10000, 5000, 8000);
            empobj.tsal(50000, 10000);
            empobj.tsal(50000, 10000, 5000, 8000, 2000, 3000);


        }
    }
}
Question
-----------
Employee Promotion Notification using Delegates in C#

**Scenario:**  
A company wants to implement a flexible employee promotion notification system. The logic for determining whether an employee qualifies for promotion can vary. The system should also notify different stakeholders (e.g., HR department, Team Lead) when an employee is promoted.

**Requirements:**

1. Define a delegate `PromotionCriteria` that takes an `Employee` object and returns a bool indicating promotion eligibility.

2. Define a delegate `Notification` that takes an `Employee` object and sends a notification (prints a message).

3. Create a class `Employee` with properties: `ID`, `Name`, `Salary`, and `Experience`.

4. Implement a static method `PromoteEmployees`, which takes a list of employees, a `PromotionCriteria` delegate instance, and one or more `Notification` delegate instances.

5. The `PromoteEmployees` method should:  
   - Iterate over the employees.  
   - Use the criteria delegate to check eligibility.  
   - For eligible employees, invoke the notification delegate(s) to send notifications.

6. In the `Main` method:  
   - Create a list of employees.  
   - Create different promotion criteria (e.g., salary above a threshold, experience more
   than 5 years).  
   - Create multiple notification methods simulating notifications to HR, Team Lead, etc.  
   - Pass delegates to the `PromoteEmployees` method and observe flexible behavior.

***
Notidication delegate example
------------------------------
namespace promotionusingdelegateforemployees
{
   public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal Salary { set; get; }

        public int Experience { set; get; }

        public Employee(int id,string name,decimal salary,int experience )
        {
            ID=id;
            Name=name;
            Salary=salary;
            Experience=experience;

        }
        public override string ToString()
        {
            return $"ID:{ID} Name:{Name} Salary:{Salary} Experience:{Experience}";
        }
    }

    public delegate bool PromotionCriteria(Employee emp);

    public delegate void Notification(Employee emp) ;
    class Program
    {

        public static bool Highsalarycrietera(Employee emp)
        {
            return emp.Salary > 80000;
        }

        public static bool Experiencecrietera(Employee emp)
        {
            return emp.Experience >= 5;
        }
        public static void SendHRNotification  (Employee emp)
        {
          Console.WriteLine($"HR Notification: Employee {emp.Name} has been promoted.");

        }
        public static void teamLeadNotification(Employee emp)
        {
            Console.WriteLine($"Team Lead Notification: Employee {emp.Name} has been promoted.");
        }

        public static void financeteamNotifcation(Employee emp)
        {
            Console.WriteLine($"Finance Team Notification: Employee {emp.Name} has been promoted.");
        }
        public static void PromoteEmployee(List<Employee> employees,
            PromotionCriteria criteria, params Notification[] notifications)
        {
            
        }
        static void Main(string[] args)
        {
            var employees = new List<Employee>()
            {
                new Employee(101,"Alice",60000,6),
                new Employee(102,"Bob",45000,4),
                new Employee(103,"Charlie",88000,7),
                new Employee(104,"David",30000,2),  
                new Employee(105,"Eve",82000,8)
            };
        }
    }
}
final code 
--------------
namespace promotionusingdelegateforemployees
{
   public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal Salary { set; get; }

        public int Experience { set; get; }

        public Employee(int id,string name,decimal salary,int experience )
        {
            ID=id;
            Name=name;
            Salary=salary;
            Experience=experience;

        }
        public override string ToString()
        {
            return $"ID:{ID} Name:{Name} Salary:{Salary} Experience:{Experience}";
        }
    }

    public delegate bool PromotionCriteria(Employee emp);

    public delegate void Notification(Employee emp) ;
    class Program
    {

        public static bool Highsalarycrietera(Employee emp)
        {
            return emp.Salary > 80000;
        }

        public static bool Experiencecrietera(Employee emp)
        {
            return emp.Experience >= 5;
        }
        public static void SendHRNotification  (Employee emp)
        {
          Console.WriteLine($"HR Notification: Employee {emp.Name} has been promoted.");

        }
        public static void teamLeadNotification(Employee emp)
        {
            Console.WriteLine($"Team Lead Notification: Employee {emp.Name} has been promoted.");
        }

        public static void financeteamNotifcation(Employee emp)
        {
            Console.WriteLine($"Finance Team Notification: Employee {emp.Name} has been promoted.");
        }
        public static void PromoteEmployee(List<Employee> employees,
            PromotionCriteria criteria, params Notification[] notifications)
        {
            foreach (var emp in employees)
            {
                if(criteria(emp))
                {
                    Console.WriteLine($"Promoted: {emp}");
                    foreach (var notify in notifications)
                    {
                        notify(emp);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var employees = new List<Employee>()
            {
                new Employee(101,"Alice",60000,6),
                new Employee(102,"Bob",45000,4),
                new Employee(103,"Charlie",88000,7),
                new Employee(104,"David",30000,2),  
                new Employee(105,"Eve",82000,8)
            };
            Console.WriteLine("Promotion based on High Salary Criteria:");
            PromoteEmployee(employees, Highsalarycrietera,
                SendHRNotification, teamLeadNotification);
            Console.WriteLine("\nPromotion based on Experience Criteria:");
            PromoteEmployee(employees, Experiencecrietera,
                SendHRNotification, financeteamNotifcation);

            Console.ReadLine();

        }
    }
}
as we have not learned List yet i am converting this program into normal static arrays lke this 

    namespace promotionusingdelegateforemployees
{
   public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal Salary { set; get; }

        public int Experience { set; get; }

        public Employee(int id,string name,decimal salary,int experience )
        {
            ID=id;
            Name=name;
            Salary=salary;
            Experience=experience;

        }
        public override string ToString()
        {
            return $"ID:{ID} Name:{Name} Salary:{Salary} Experience:{Experience}";
        }
    }

    public delegate bool PromotionCriteria(Employee emp);

    public delegate void Notification(Employee emp) ;
    class Program
    {

        public static bool Highsalarycrietera(Employee emp)
        {
            return emp.Salary > 80000;
        }

        public static bool Experiencecrietera(Employee emp)
        {
            return emp.Experience >= 5;
        }
        public static void SendHRNotification  (Employee emp)
        {
          Console.WriteLine($"HR Notification: Employee {emp.Name} has been promoted.");

        }
        public static void teamLeadNotification(Employee emp)
        {
            Console.WriteLine($"Team Lead Notification: Employee {emp.Name} has been promoted.");
        }

        public static void financeteamNotifcation(Employee emp)
        {
            Console.WriteLine($"Finance Team Notification: Employee {emp.Name} has been promoted.");
        }
        public static void PromoteEmployee(Employee[] employees,
            PromotionCriteria criteria, params Notification[] notifications)
        {
            foreach (var emp in employees)
            {
                if(criteria(emp))
                {
                    Console.WriteLine($"Promoted: {emp}");
                    foreach (var notify in notifications)
                    {
                        notify(emp);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var employees = new Employee[]
            {
                new Employee(101,"Alice",60000,6),
                new Employee(102,"Bob",45000,4),
                new Employee(103,"Charlie",88000,7),
                new Employee(104,"David",30000,2),
                new Employee(105,"Eve",82000,8)
            };
            Console.WriteLine("Promotion based on High Salary Criteria:");
            PromoteEmployee(employees, Highsalarycrietera,
                SendHRNotification, teamLeadNotification);
            Console.WriteLine("\nPromotion based on Experience Criteria:");
            PromoteEmployee(employees, Experiencecrietera,
                SendHRNotification, financeteamNotifcation);

            Console.ReadLine();

        }
    }
}

Trypars ,parse and covert clases 
----------------------------------
namespace Tryparsedemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tryparsedemo();
            Console.ReadLine();
        }

        private static void tryparsedemo()
        {

            Console.WriteLine("Enter Product Price ");
            string input = Console.ReadLine();
            bool isvalid = decimal.TryParse(input, out decimal price);
            // if it becomes true then it will store its value in price variable
            // try parse return type is boolean
            // for any type i can do tryparse ,here this will not throw exception 
            // becasue i am handing in else block the logic 
            if (isvalid)
            {
                Console.WriteLine($"Product Price is : {price}");
            }
            else
            {
                Console.WriteLine("Invalid Price Input please enter numeric value");
            }
        }
    }
}

Next updated code 
-----------------

namespace Tryparsedemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tryparsedemo();
            parsedemo();

            Console.ReadLine();
        }

        private static void parsedemo()
        {
            Console.WriteLine("Enter Product Price ");
            decimal price = decimal.Parse(Console.ReadLine());
            //here if u enter wrong value exception will be thrown
            Console.WriteLine($"Product Price is : {price}");
        }

        private static void tryparsedemo()
        {

            Console.WriteLine("Enter Product Price ");
            string input = Console.ReadLine();
            bool isvalid = decimal.TryParse(input, out decimal price);
            // if it becomes true then it will store its value in price variable
            // try parse return type is boolean
            // for any type i can do tryparse ,here this will not throw exception 
            // becasue i am handing in else block the logic 
            if (isvalid)
            {
                Console.WriteLine($"Product Price is : {price}");
            }
            else
            {
                Console.WriteLine("Invalid Price Input please enter numeric value");
            }
        }
    }
}
final code 
------------
namespace Tryparsedemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tryparsedemo();
            //parsedemo();

            Console.WriteLine("Enter Product Price ");
            decimal price = Convert.ToDecimal(string.IsNullOrWhiteSpace(Console.ReadLine()));
            
            Console.WriteLine($"Product Price is : {price}");
            Console.ReadLine();
        }

        private static void parsedemo()
        {
            Console.WriteLine("Enter Product Price ");
            decimal price = decimal.Parse(Console.ReadLine());
            //here if u enter wrong value exception will be thrown
            Console.WriteLine($"Product Price is : {price}");
        }

        private static void tryparsedemo()
        {

            Console.WriteLine("Enter Product Price ");
            string input = Console.ReadLine();
            bool isvalid = decimal.TryParse(input, out decimal price);
            // if it becomes true then it will store its value in price variable
            // try parse return type is boolean
            // for any type i can do tryparse ,here this will not throw exception 
            // becasue i am handing in else block the logic 
            if (isvalid)
            {
                Console.WriteLine($"Product Price is : {price}");
            }
            else
            {
                Console.WriteLine("Invalid Price Input please enter numeric value");
            }
        }
    }
}

use of Is and As operator 
--------------------------
In C#, is is for type checking and as is for safe casting (returns null if the cast fails). A clean way to show both is with an inheritance example.

namespace IsAsDemo
{
    class Employee
    {
         public string Name { get; set; }
        public Employee(string name)
        {
            Name = name;
        }

    }
    class Manager : Employee
    {
        public Manager(string name) : base(name)
        {
        }
        public void ApproveLeave()
        {
            Console.WriteLine($" {Name} approved leave request");
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

final code 
----------
namespace IsAsDemo
{
    class Employee
    {
         public string Name { get; set; }
        public Employee(string name)
        {
            Name = name;
        }

    }
    class Manager : Employee
    {
        public Manager(string name) : base(name)
        {
        }
        public void ApproveLeave()
        {
            Console.WriteLine($" {Name} approved leave request");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Alice");
            Employee emp2 = new Manager("Bob");
            // using is 
            if ((emp1 is Manager))
            {
                Console.WriteLine("emp1 is manager");
            }
            else
            {
                Console.WriteLine("emp1 is not manager");
            }
            if (emp2 is Manager)
            {
                Console.WriteLine("emp2 is manager");
            }
            else
            {
                Console.WriteLine("emp2 is not manager");
            }
            //now using as ..for safe typecastng
            Manager mgr1=emp1 as Manager;//emp1 isnot a manager so mgr1 becomes null
            Manager mgr2=emp2 as Manager;
            if (mgr1 != null)
            {
                mgr1.ApproveLeave();
            }
            else
            {
                Console.WriteLine("emp1 is not a manager, cannot approve leave");
            }
            if (mgr2 != null)
            {
                mgr2.ApproveLeave();
            }
            else
            {
                Console.WriteLine("emp2 is not a manager, cannot approve leave");
            }
            Console.ReadLine();
        }
    }
}
What to explain to students
emp2 is Manager
Returns true if emp2 refers to a Manager (or derived from Manager).

emp2 as Manager

If compatible → returns a Manager reference.

If not compatible → returns null (no exception).

Pattern you can emphasize:

Use is when you only want to check the type:

if (obj is Manager) { ... }

Use as when you want to cast and then use the object:

Manager m = obj as Manager;
if (m != null)
{
    m.ApproveLeave();
}

Partial class 
-------------
when  i want to share my class among multiple developers means i want to distribute same class to multiple developers then i can write code using 
partial key word here 

namespace partialclassdemo
{

    public partial class Employee
    {
        public int Empid { get; set; }
        public string EmpName { get; set; }

        public Employee(int empid,string empname)
        {
            this.Empid = empid;
            this.EmpName = empname;
        }
    }

    public partial class Employee
    {
        public void DisplayEmployee()
        {
            Console.WriteLine($"{Empid}--{EmpName}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee empobj = new Employee(101, "kiran");
            empobj.DisplayEmployee();
            Console.ReadLine();
        }
    }
}

    
Finilize and dispose methods
------------------------------
Garbage collection :
---------------------
when the object goes out of scope it will call its inbuilt method finilize() where the destructors will be called but in windows application or 
    console applicationn i cannot see those destructor codes why because they are called at the background and to collect those object explicitly i will use gc.collect method 


Now create a windows application and write the code like this here one button click  event is there 





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace garbalgecollector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class A
        {
            public A()
            {
                MessageBox.Show("Creating A");
            }
            ~A()
            {
                for (int i = 0; i < 100000; i++) ;
                MessageBox.Show("Desctructor  A");
            }

        }
        class B : A
        {
            public B()
            {
                MessageBox.Show("Creating B");
            }
            ~B()
            {
                for (int i = 0; i < 100000; i++) ;
                MessageBox.Show("Desctructor  B");
            }

        }
        class C : B
        {

            public C()
            {
               MessageBox.Show("Creating C");
            }
            ~C() 
            {
                for (int i = 0; i < 100000; i++) ;
                MessageBox.Show("Desctructor  C");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            C cc = new C();
            
          
            Console.ReadLine();
        }

       
    }
}

after wirting like this also after closing the application of windows u cant see the destructor code 

so go to program.cs file of windows and write like this 

namespace Garbagcollectordemo1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}

so last three lines are important and add it same thing do it for next program also 

another logic on garbage collector 
-------------------------------------


here also same logic when i closed the winform i cant see the method when i am supressing it using dispose method otherwise i will see it is liek this try okay .

namespace garbagecollectordemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        class GarbageCollection : IDisposable
        {
            public void dosomething()
            {
                MessageBox.Show("performing usual tasks");
            }
            public void Dispose()
            {
                GC.SuppressFinalize(this);
                MessageBox.Show("disposing object");
                MessageBox.Show("freeing the resouces captured by object");
            }
            ~GarbageCollection()
            {
                MessageBox.Show("destryig object");
                MessageBox.Show("freeing the resouces captured by object");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GarbageCollection garbage = new GarbageCollection();
            garbage.dosomething();
           // garbage.Dispose(); //if uncomment this code then destructor code i cant see 
           
        }
    }
}

again in this program.cs write these three lines of code 

namespace garbagecollectordemo2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}


Indexers
---------
namespace Indexerdemo
{
    class abcd
    {
        private string[] val = new string[3];
    }
     class Program
    {
        static void Main(string[] args)
        {
          abcd obj=new abcd();
            //when  i want to use object array as property 
            // then  i will use indexers
            obj[0] = "Csharp";
            obj[1] = "Java";
            obj[2] = "C++";
        }
    }
}

final code
----------
namespace Indexerdemo
{
    class abcd
    {
        private string[] val = new string[3];

        public string this[int index]
        {
            set
            {
                val[index] = value;

            }
            get
            {
                return val[index];
            }

        }

    }
     class Program
    {
        static void Main(string[] args)
        {
          abcd obj=new abcd();
            //when  i want to use object array as property 
            // then  i will use indexers
            obj[0] = "Csharp";
            obj[1] = "Java";
            obj[2] = "C++";


            // obj[3] = "python";// out of bound exception 

            Console.WriteLine($"{obj[0]}-{obj[1]}-{obj[2]}");
        }
    }
}

Collections 
--------------
Non generic collections
----------------------
using System.Collections;

namespace NonGenericArrayListDemo
{
     class Program
    {
        static void Main(string[] args)
        {
            ArrayList obj = new ArrayList();
            obj.Add(1);
            obj.Add(true);
            obj.Add("Raghavendra");
            obj.Add(DateTime.Now);
            obj.Add(234.567);

            Console.WriteLine($"\n no of elements:{obj.Count}");
            Console.WriteLine($"\n capacity :{obj.Capacity}");
            foreach(var ele in obj)
            {
                Console.WriteLine(ele);
            }
            int[] fourmore = new int[] { 100, 200, 300, 400 };
            obj.AddRange(fourmore);
            Console.WriteLine($"\n no of elements:{obj.Count}");
            Console.WriteLine($"\n capacity :{obj.Capacity}");
            foreach (var ele in obj)
            {
                Console.WriteLine(ele);
            }
            obj.Insert(0, "first");
            obj.RemoveAt(3);
            Console.WriteLine($"\n no of elements:{obj.Count}");
            Console.WriteLine($"\n capacity :{obj.Capacity}");
            foreach (var ele in obj)
            {
                Console.WriteLine(ele);
            }
            Console.ReadLine();
        }
    }
}
HashTable
------------
using System.Collections;

namespace NonGenericHashHashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "kiran");
            ht.Add('a', 789.77);
            ht.Add("mahesh",DateTime.Now);

            foreach(DictionaryEntry entry in ht)
            {
                Console.WriteLine($"ID:{entry.Key}---Value:{entry.Value}");
            }
            if(ht.ContainsKey(1))
            {
                Console.WriteLine($"ID:1,value is {ht[1]}");
            };
            ht.Remove('a');
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine($"ID:{entry.Key}---Value:{entry.Value}");
            }
            Console.ReadLine();
        }
    }
}
here also i can stroee any thng but in the form key value pair agina key can be anything and value can be anything
Sorted List 
-------------
using System.Collections;

namespace NonGenericSortedListdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList students=new SortedList();
            students.Add(101, "Alice");
            students.Add(102, "Bob");
            students.Add(105, "Charlie");
            students.Add(104, "david");
            students.Add(103, "kiran");

            foreach(DictionaryEntry entry in students)
            {
                Console.WriteLine($"Student id:{entry.Key}--StudentName:{entry.Value}");
            }
            Console.ReadLine();

        }
    }
}
