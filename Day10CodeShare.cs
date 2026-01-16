List Demo of geenric 
--------------------
namespace GenericListDemo
{

    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    
        
        static   List<Customer> clist = new List<Customer>()
            {
            new Customer {CustomerID=101,CustomerName="ravi"},
            new Customer {CustomerID=102,CustomerName="Sita"},
            new Customer {CustomerID=103,CustomerName="sohan"},
            };
        public static List<Customer> retrive()
        {
           
            return clist; 
        }

        public static void PrintCustomers(List<Customer> clist)
        {
            Console.WriteLine("\n Displaying customer ");
            foreach (Customer c in clist)
            {
                Console.WriteLine($"{c.CustomerID}---{c.CustomerName}");
            }
        }

        public static void insertcustomer(Customer c,List<Customer> clist)
        {
            clist.Add(c);
        }

        public static Customer findcustomer(int custid,List<Customer> clist)
        {
            Customer customerfound = null;
            foreach(Customer c in clist)
            {
                if(c.CustomerID==custid)
                {
                    customerfound = c;
                    break;
                }
            }
            return customerfound;
        }
        public static void updatecustomer(int custid,List<Customer> clist)
        {
            for(int i=0;i<clist.Count;i++)
            {
                if (clist[i].CustomerID==custid)
                {
                    Console.WriteLine("\n enter new name :");
                    string newname = Console.ReadLine();
                    clist[i].CustomerName = newname;
                }
            }
        }

    }
    internal class Program
    {


        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(29);
            numbers.Add(45);

            List<string> names = new List<string>()
            { 
            "ravi",
            "sudha",
            "mohan"
            
            };

            foreach (int num in numbers)
            {
                Console.Write($"\t{num}");
            }
            Console.WriteLine();
            foreach(string name in names)
            {
                Console.WriteLine(name); 
            }
            var array = new int[] { 1, 2, 3, 2, 3, 4, 5, 6, 4, 8, 9, 10, 5 };//static array
            var result = new List<int>();
            foreach(int num in array)
            {
                bool found = false;
                foreach(int ele in result)
                {
                    if(ele==num) found = true;
                }
                if(!found)
                {
                    result.Add(num);
                }
            }

            foreach (int ele in result)
            {
                Console.Write($"\t{ele}"); 
            }

            List<Customer> custlist = Customer.retrive();
            Customer.PrintCustomers(custlist);
            Customer newcustomer = new Customer()
            {
                CustomerID=104,
                CustomerName="mahesh"
            };
            Customer.insertcustomer(newcustomer, custlist);
            Customer.PrintCustomers(custlist);
            Console.WriteLine("\n enter id of student to find customer name ");

            int custid = Convert.ToInt16(Console.ReadLine());
           Customer custfound= Customer.findcustomer(custid, custlist);
            if(custfound!=null)
            {
                Console.WriteLine($"The customer with {custfound.CustomerID} is having name {custfound.CustomerName}");
            }
            else
            {
                Console.WriteLine("The customer is not there in list ");
            }
            Console.WriteLine("\n enter the id of customer who u want to update name");
            int custid2 = Convert.ToInt16(Console.ReadLine());
            Customer.updatecustomer(custid2, custlist);
            Customer.PrintCustomers(custlist);

                Console.ReadLine();
        }
    }
}

final code 
-----------
namespace GenericListDemo
{

    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    
        
        static   List<Customer> clist = new List<Customer>()
            {
            new Customer {CustomerID=101,CustomerName="ravi"},
            new Customer {CustomerID=102,CustomerName="Sita"},
            new Customer {CustomerID=103,CustomerName="sohan"},
            };
        public static List<Customer> retrive()
        {
           
            return clist; 
        }

        public static void PrintCustomers(List<Customer> clist)
        {
            Console.WriteLine("\n Displaying customer ");
            foreach (Customer c in clist)
            {
                Console.WriteLine($"{c.CustomerID}---{c.CustomerName}");
            }
        }

        public static void insertcustomer(Customer c,List<Customer> clist)
        {
            clist.Add(c);
        }

        public static Customer findcustomer(int custid,List<Customer> clist)
        {
            Customer customerfound = null;
            foreach(Customer c in clist)
            {
                if(c.CustomerID==custid)
                {
                    customerfound = c;
                    break;
                }
            }
            return customerfound;
        }
        public static void updatecustomer(int custid,List<Customer> clist)
        {
            for(int i=0;i<clist.Count;i++)
            {
                if (clist[i].CustomerID==custid)
                {
                    Console.WriteLine("\n enter new name :");
                    string newname = Console.ReadLine();
                    clist[i].CustomerName = newname;
                }
            }
        }
        public static void deletecustomer(int custid,List<Customer> clist)
        {
            for (int i = 0; i < clist.Count; i++)
            {
                if (clist[i].CustomerID == custid)
                {
                    clist.RemoveAt(i);
                }
            }
        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(29);
            numbers.Add(45);
            
            

            List<string> names = new List<string>()
            { 
            "ravi",
            "sudha",
            "mohan"
            
            };

            foreach (int num in numbers)
            {
                Console.Write($"\t{num}");
            }
            Console.WriteLine();
            foreach(string name in names)
            {
                Console.WriteLine(name); 
            }
            var array = new int[] { 1, 2, 3, 2, 3, 4, 5, 6, 4, 8, 9, 10, 5 };//static array
            var result = new List<int>();
            foreach(int num in array)
            {
                bool found = false;
                foreach(int ele in result)
                {
                    if(ele==num) found = true;
                }
                if(!found)
                {
                    result.Add(num);
                }
            }

            foreach (int ele in result)
            {
                Console.Write($"\t{ele}"); 
            }

            List<Customer> custlist = Customer.retrive();
          
            Customer.PrintCustomers(custlist);
            Customer newcustomer = new Customer()
            {
                CustomerID=104,
                CustomerName="mahesh"
            };
            Customer.insertcustomer(newcustomer, custlist);
            Customer.PrintCustomers(custlist);
            Console.WriteLine("\n enter id of student to find customer name ");

            int custid = Convert.ToInt16(Console.ReadLine());
           Customer custfound= Customer.findcustomer(custid, custlist);
            if(custfound!=null)
            {
                Console.WriteLine($"The customer with {custfound.CustomerID} is having name {custfound.CustomerName}");
            }
            else
            {
                Console.WriteLine("The customer is not there in list ");
            }
            Console.WriteLine("\n enter the id of customer who u want to update name");
            int custid2 = Convert.ToInt16(Console.ReadLine());
            Customer.updatecustomer(custid2, custlist);
            Customer.PrintCustomers(custlist);

            Console.WriteLine("enter the customer id whom u want to delete ");
            int custid3 = Convert.ToInt32(Console.ReadLine());

            Customer.deletecustomer(custid3, custlist);
            Customer.PrintCustomers(custlist);
                Console.ReadLine();
        }
    }
}

Dictionary generic one (here i will store data in key value pair but it is generic i have to mention some type and according to that type only i can enter values)
---------------------
namespace GenericDictionayDemo
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> dic=new Dictionary<int,string>();
            Console.WriteLine("\n Enter number of elements in dictionary ");
            int counter=Convert.ToInt32(Console.ReadLine());
            for(int i=0;i< counter;i++)
            {
                Console.WriteLine("enter key ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter value");
                string value = Console.ReadLine();  
                dic.Add(key, value);
            }
            Console.WriteLine("\n Printing the dictionary");
            foreach (KeyValuePair<int, string> pair in dic)
            {
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            }
            Console.ReadLine();
        }
    }
}
updated code
--------------
namespace GenericDictionayDemo
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> dic=new Dictionary<int,string>();
            Console.WriteLine("\n Enter number of elements in dictionary ");
            int counter=Convert.ToInt32(Console.ReadLine());
            for(int i=0;i< counter;i++)
            {
                Console.WriteLine("enter key ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter value");
                string value = Console.ReadLine();  
                dic.Add(key, value);
            }
            Console.WriteLine("\n Printing the dictionary");
            foreach (KeyValuePair<int, string> pair in dic)
            {
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            }

            Dictionary <double,Customer> dicofcustomer=new Dictionary<double,Customer>()
            {
                {101.456,new Customer{Id=101,Name="suresh"} } ,
                {234.567,new Customer{Id=105,Name="sharavan" } },
                {345.456,new Customer{Id=101,Name="suresh"}
                }

            };
            
            Console.ReadLine();
        }
    }
}

stack dmeo (LIFO)(it exsist in both generic and non generic )
    --------------
    namespace stacdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numstack=new Stack<int>();
            //push elelments into stack 
            //lifo

            numstack.Push(10);
            numstack.Push(20);
            numstack.Push(30);
            numstack.Push(40);

            Console.WriteLine("\n printing the elements of stack");
            foreach(int i in numstack)
            {
                Console.WriteLine(i);
            }
            //pop elelemts frm stack 
            int popedelement=numstack.Pop();
            Console.WriteLine($"popped element :{popedelement}");
            Console.WriteLine("\n printing the elements of stack");
            foreach (int i in numstack)//it is not keeping in list removing it
            {
                Console.WriteLine(i);
            }
            //peek the top element without removing it 

            int topelement=numstack.Peek();
            Console.WriteLine($"Peeked element:{topelement}");
            Console.WriteLine("\n printing the elements of stack");
            foreach (int i in numstack)//it is  keeping in list 
            {
                Console.WriteLine(i);
            }
        }
    }
}
Queue demo (FIFO)
    --------------
namespace QueueDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Queue<string> queue = new Queue<string>();
            //FIFO
            queue.Enqueue("Alice");
            queue.Enqueue("Bob");
            queue.Enqueue("Charlie");
            queue.Enqueue("David");


            Console.WriteLine("\n elements in queue");
            foreach(string name in queue)
            {
                Console.WriteLine(name);
            }
            //Dequeing the elelmt from the queue 
            string dequedelelemtn=queue.Dequeue();
            Console.WriteLine($"The element dequeed is {dequedelelemtn}");

            Console.WriteLine("\n elements in queue");
            foreach (string name in queue)
            {
                Console.WriteLine(name);
            }

            //peeking 
            string peekedeleemnt = queue.Peek();
            Console.WriteLine($"The element peeekded is {peekedeleemnt}");

            Console.WriteLine("\n elements in queue");
            foreach (string name in queue)
            {
                Console.WriteLine(name);
            }
        }
    }
}

IComparable demo
-------------------

add this class above class program 

    class Employee
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public decimal Salary { get; set; }

            public Employee(string name, int id, decimal salary)
            {
                Name = name;
                Id = id;
                Salary = salary;
            }

         public override string ToString()
            {
                return $"{Name} (ID: {Id}, Salary: {Salary:C})";
            }
    }

write the below code in main method 

List<int> numbers = new List<int>() {12,67,8,2,78,43,22,90,129 };
            // primitive data types 

            numbers.Sort();
            foreach (int i in numbers)
            {
                Console.Write($"{i}  ");
            }

            List<Employee> employees = new List<Employee>() 
            {
                new Employee("Jane", 102, 75000m),
               new Employee("John", 101, 90000m),
                new Employee("Mike", 103, 65000m)
            };

            employees.Sort();
            Console.WriteLine("\n");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

