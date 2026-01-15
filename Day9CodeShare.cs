
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}


