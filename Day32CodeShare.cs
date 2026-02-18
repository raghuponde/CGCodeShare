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

I want to add ann new employee who has joined in year 2003 


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
            employees.Add(new Employee { ID = 4,
                Name = "Linda", HireDate = new DateTime(2003, 3, 5) });
            foreach (Employee e in query)
            {
                Console.WriteLine($"{e.Name}");
            }
            Console.ReadLine();
        }
    }
}

In the above code i am getting eror because i a using IEnumerable interface to read th colelction so change the code like this 

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
            List<Employee> employees = new List<Employee>()
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
            employees.Add(new Employee { ID = 4,
                Name = "Linda", HireDate = new DateTime(2003, 3, 5) });
            foreach (Employee e in query)
            {
                Console.WriteLine($"{e.Name}");
            }
            Console.ReadLine();
        }
    }
}

Deffered executin or lazy loading 
----------------------------------
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
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ID=1,Name="Raghu" ,HireDate=new DateTime(2002,3,5)},
                new Employee{ID=2,Name="Mohan" ,HireDate=new DateTime(2001,3,5)},
                new Employee{ID=3,Name="Kiran" ,HireDate=new DateTime(2007,3,5)},

            };

            IEnumerable<Employee> query  = from e in employees
                                           where e.HireDate.Year < 2005
                                           orderby e.Name
                                           select e;


            employees.Add(new Employee
            {
                ID = 4,
                Name = "Linda",
                HireDate = new DateTime(2003, 3, 5)
            });


            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.Name}");
            }
           
          
          
            Console.ReadLine();
        }
    }
}
here i had added linda later then also i am able to see linda when i am printing it this is called deffereed execution means all the activities 
which i had created or done on collection it rememebrs and whenn u print it wil show the resut of it 

now if i am want to do immedirate execution i will use TOList means forcefully i am executiing th code and whatver new operation like 
add ing linda will not be counted so as u have done to list then when i print i will not get get linda which is immedieate execution 

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
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ID=1,Name="Raghu" ,HireDate=new DateTime(2002,3,5)},
                new Employee{ID=2,Name="Mohan" ,HireDate=new DateTime(2001,3,5)},
                new Employee{ID=3,Name="Kiran" ,HireDate=new DateTime(2007,3,5)},

            };

            IEnumerable<Employee> query  =( from e in employees
                                           where e.HireDate.Year < 2005
                                           orderby e.Name
                                           select e).ToList();//immedeate execution 


            employees.Add(new Employee
            {
                ID = 4,
                Name = "Linda",
                HireDate = new DateTime(2003, 3, 5)
            });


            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.Name}");
            }
           
          
          
            Console.ReadLine();
        }
    }
}

