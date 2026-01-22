
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqtoEmployeeObjectDemo
{
    internal class Employee
    {
        public int EmployeeID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string City { set; get; }
        public int Sal { set; get; }



    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqtoEmployeeObjectDemo
{
    internal class EmpRepository
    {
        public static List<Employee> Retrive()
        {

            List<Employee> emplist = new List<Employee>()
            {

                new Employee{EmployeeID=101,FirstName="sudha",LastName="rani",City="Bangalore",Sal=34000},
                new Employee{EmployeeID=102,FirstName="Madhu",LastName="sudhan",City="Hyderabad",Sal=30000},
                 new Employee{EmployeeID=103,FirstName="Kiran ",LastName="Kumar",City="Hyderabad",Sal=35000},

                new Employee{EmployeeID=104,FirstName="sita",LastName="rani",City="Hyderabad",Sal=25000},

               new Employee{EmployeeID=105,FirstName="rakesh",LastName="sharma",City="Bangalore",Sal=19000},

               new Employee{EmployeeID=106,FirstName="Mahesh",LastName="Babu",City="Mysore",Sal=36000}




            };

            return emplist;
        }

    }
}

namespace LinqtoEmployeeobjectdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = EmployeeRepository.Retrive();

            var employees2 = from emp in EmployeeRepository.Retrive() select emp;

            //here above i had used two ways of retriving one is what we do in normal way 
            // another is query syntx in both the cases i can see list of employees 

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }

            Console.WriteLine("\n\n");
            foreach (var employee in employees2)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }
            Console.WriteLine("Listing employees order by city and then order by sal");
            Console.WriteLine("\n\n");
            var usingorderbythen = employees2.OrderBy(x => x.City).ThenBy(x => x.Sal);//method syntax of linq
            var usingorderbythen2 = from emp in employees2 orderby emp.City, emp.Sal select emp;//query syntax of linq
            Console.WriteLine("\n\n");
            foreach(var employee in usingorderbythen)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");


            }
            Console.WriteLine("\n\n");
            foreach (var employee in usingorderbythen2)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");


            }

            //when u want to project only few proeprties or columns then u have to use different syntax when u say select emp
            // all columns are selected but now in the case syntax u have to learn 

            var firstnameandcity = from emp in employees2
                                   select new
                                   {
                                       emp.FirstName,
                                       emp.City
                                   };

            var firstnameandcity2 = from emp in employees
                                    select new
                                    {
                                        fname=emp.FirstName,
                                        cityname=emp.City
                                    };

            Console.WriteLine("\n\n");
            foreach (var employee in firstnameandcity)// here i can write firstnameandcity2 
            {
                Console.WriteLine($"{employee.FirstName}--{employee.City}");


            }
            Console.WriteLine("\n\n");
            foreach (var employee in firstnameandcity2)// here i can write firstnameandcity2 
            {
                Console.WriteLine($"{employee.fname}--{employee.cityname}");


            }

            var firstnameandcity3 =employees.Select(x=>new { x.FirstName, x.City });//metthod syntax 
            Console.WriteLine("\n\n");
            foreach (var employee in firstnameandcity3)// here i can write firstnameandcity2 
            {
                Console.WriteLine($"{employee.FirstName}--{employee.City}");


            }

            // i want to concatante frist name andn last name of employees and give it as full name 
            var fullnamedisplay = from emp in employees2
                                  select new
                                  {
                                      fullname = emp.FirstName + " " + emp.LastName
                                  };

            Console.WriteLine("\n");
            foreach (var employee in fullnamedisplay)
            {
                Console.WriteLine($"{employee.fullname}");
            }

            Console.WriteLine("\n\n");
            //i want to skip  first 2 employees and and want to take remaining 3 and last employee i want to leave
            var fewskipusage = employees.Skip(2).Take(3);
            Console.WriteLine("\n\n");
            foreach(var employee in fewskipusage)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");

            }
        }
    }
}
