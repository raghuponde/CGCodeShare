
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
                new Employee{EmployeeID=101,FirstName="Madhu",LastName="sudhan",City="Hyderabad",Sal=30000},
                 new Employee{EmployeeID=103,FirstName="Kiran ",LastName="Kumar",City="Hyderabad",Sal=35000},

                new Employee{EmployeeID=104,FirstName="sita",LastName="rani",City="Hyderabad",Sal=25000},

               new Employee{EmployeeID=105,FirstName="rakesh",LastName="sharma",City="Bangalore",Sal=19000},

               new Employee{EmployeeID=106,FirstName="Mahesh",LastName="Babu",City="Mysore",Sal=36000}




            };

            return emplist;
        }

    }
}

