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
                Console.ReadLine();
        }
    }
}
