






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
Taking simmple exmple chec last code 

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
            //taking simple code like below
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var query1 = numbers.Where(n => n > 2);//.ToList();  
            numbers.Add(6);  // Affects query
            foreach (var n in query1) 
            Console.WriteLine(n);  // Outputs: 3,4,5,6 

            // in the above coding if u put to list of comments u are doing
            // immedteate execution and not doing means deffered execution 
            // in immediate 6 is not printed and in defferd one 6 is printed 


            Console.ReadLine();
        }
    }
}

Most .NET built-in collection classes implement IEnumerable<T> (or non-generic IEnumerable) by default, enabling direct foreach usage without any implementation on your part.

Common Built-in Classes with IEnumerable
These work directly with foreach out-of-the-box:


Arrays: int[], string[], object[]
Collections: List<T>, Dictionary<TKey,TValue>, HashSet<T>
Queues: Queue<T>, ConcurrentQueue<T>
Stacks: Stack<T>
Linked Lists: LinkedList<T>
Others: ObservableCollection<T>, SortedList<TKey,TValue>
Strings: string (as char sequence)


// All these work directly with foreach - no implementation needed

int[] numbers = {1, 2, 3};
foreach (int n in numbers) Console.WriteLine(n);  // Works!

List<string> names = new List<string> {"Alice", "Bob"};
foreach (string name in names) Console.WriteLine(name);  // Works!

Dictionary<int, string> dict = new Dictionary<int, string> {{1, "One"}};
foreach (var kvp in dict) Console.WriteLine($"{kvp.Key}: {kvp.Value}");  // Works!

string text = "Hello";
foreach (char c in text) Console.WriteLine(c);  // Works! (chars)

next program
-------------
namespace IEnumerableDemo2
{
    class Employee
    {
        public string Name { set; get; }
        public int Salary { set; get; }
        public int DepartmentId { set; get; }

        public Employee(string name1,int salary1,int deptid)
        {
            Name = name1;
            Salary = salary1;
            DepartmentId = deptid;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }// Works!

            List<string> names = new List<string> { "Alice", "Bob" };
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }// Works!

            Dictionary<int, string> dict = new Dictionary<int, string> { { 1, "One" } };
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}")
                    ;  // Works!
            }

            string text = "Hello";
            foreach (char c in text)
            {
                Console.WriteLine(c);
            }// Works! (chars)

            Console.ReadLine();

        }
    }
}
udpated code 
-------------
namespace IEnumerableDemo2
{
    class Employee
    {
        public string Name { set; get; }
        public int Salary { set; get; }
        public int DepartmentId { set; get; }

        public Employee(string name1,int salary1,int deptid)
        {
            Name = name1;
            Salary = salary1;
            DepartmentId = deptid;
        }
    }
    public class EmployeeCollection
    {
        private readonly List<Employee> _employees;

        public EmployeeCollection()
        {
            _employees = new List<Employee>
            {

   new Employee("Alice", 50000, 1),
            new Employee("Bob", 80000, 1),
            new Employee("Charlie", 60000, 2),
            new Employee("Diana", 90000, 2)

            };
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = new EmployeeCollection();
            Console.WriteLine("\nDisplaying all employees");
            foreach(Employee e in employees)
            {
                Console.WriteLine($"{e.Name}: ${e.Salary}, Dept {e.DepartmentId}");
            }
                
            int[] numbers = { 1, 2, 3 };
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }// Works!

            List<string> names = new List<string> { "Alice", "Bob" };
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }// Works!

            Dictionary<int, string> dict = new Dictionary<int, string> { { 1, "One" } };
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}")
                    ;  // Works!
            }

            string text = "Hello";
            foreach (char c in text)
            {
                Console.WriteLine(c);
            }// Works! (chars)

            Console.ReadLine();

        }
    }
}

so in the above code i am getting error i want to run the colection using for each it is not allowing as 
it is user defiend class i have to implement IEnumerable interface where yield method is used yieeld means disaply that output 
using System.Collections;

namespace IEnumerableDemo2
{
    class Employee
    {
        public string Name { set; get; }
        public int Salary { set; get; }
        public int DepartmentId { set; get; }

        public Employee(string name1,int salary1,int deptid)
        {
            Name = name1;
            Salary = salary1;
            DepartmentId = deptid;
        }
    }
    public class EmployeeCollection: IEnumerable<Employee>
    {
        private readonly List<Employee> _employees;

        public EmployeeCollection()
        {
            _employees = new List<Employee>
            {

   new Employee("Alice", 50000, 1),
            new Employee("Bob", 80000, 1),
            new Employee("Charlie", 60000, 2),
            new Employee("Diana", 90000, 2)

            };
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var emp in _employees )
            {
                yield return emp;
            }
        }

        IEnumerator<Employee> IEnumerable<Employee>.GetEnumerator()
        {
            return _employees.GetEnumerator();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = new EmployeeCollection();
            Console.WriteLine("\nDisplaying all employees");
            foreach(Employee e in employees)
            {
                Console.WriteLine($"{e.Name}: ${e.Salary}, Dept {e.DepartmentId}");
            }
                
            int[] numbers = { 1, 2, 3 };
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }// Works!

            List<string> names = new List<string> { "Alice", "Bob" };
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }// Works!

            Dictionary<int, string> dict = new Dictionary<int, string> { { 1, "One" } };
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}")
                    ;  // Works!
            }

            string text = "Hello";
            foreach (char c in text)
            {
                Console.WriteLine(c);
            }// Works! (chars)

            Console.ReadLine();

        }
    }
}


