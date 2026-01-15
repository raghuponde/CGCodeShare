
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
