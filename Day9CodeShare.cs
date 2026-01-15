
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

    
