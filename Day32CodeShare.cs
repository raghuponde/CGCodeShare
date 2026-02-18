namespace IEnumerableDemo
{

    class Employee
    {
        public int ID { set; get; }
        public string Name { set; get; }

        public DateTime HireDate { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = new List<Employee>()
            {
                new Employee{ID=1,Name="Raghu" ,HireDate=new DateTime(2002,3,5)},
                new Employee{ID=2,Name="Mohan" ,HireDate=new DateTime(2001,3,5)},
                new Employee{ID=3,Name="Kiran" ,HireDate=new DateTime(2007,3,5)},

            };

            foreach(Employee e in employees)
            {
                Console.WriteLine($"{e.Name}");
            }
            Console.ReadLine();
        }
    }
}

in the above i want to implment filtering means i want to get emplyees which hired befoe 2005

    
namespace IEnumerableDemo
{

    class Employee
    {
        public int ID { set; get; }
        public string Name { set; get; }

        public DateTime HireDate { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = new List<Employee>()
            {
                new Employee{ID=1,Name="Raghu" ,HireDate=new DateTime(2002,3,5)},
                new Employee{ID=2,Name="Mohan" ,HireDate=new DateTime(2001,3,5)},
                new Employee{ID=3,Name="Kiran" ,HireDate=new DateTime(2007,3,5)},

            };

            IEnumerable<Employee> query = from e in employees
                                          where e.HireDate.Year < 2005
                                          orderby e.Name
                                          select e;

            //foreach(Employee e in employees)
            //{
            //    Console.WriteLine($"{e.Name}");
            //}

            foreach (Employee e in query)
            {
                Console.WriteLine($"{e.Name}");
            }
            Console.ReadLine();
        }
    }
}
