List Demo of geenric 
--------------------
namespace GenericListDemo
{

    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public static List<Customer> retrive()
        {
            List<Customer> clist = new List<Customer>() 
            {
            new Customer {CustomerID=101,CustomerName="ravi"},
            new Customer {CustomerID=102,CustomerName="Sita"},
            new Customer {CustomerID=103,CustomerName="sohan"},
            };
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
            Console.ReadLine();
        }
    }
}

