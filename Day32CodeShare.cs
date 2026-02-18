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
