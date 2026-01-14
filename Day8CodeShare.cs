
namespace GenericsDemo
{
    
    class Program
    {

        public static void swap(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }

        public static void swap(ref DateTime x,ref DateTime y)
        {
            DateTime temp;
            temp = x;
            x = y;
            y = temp;
        }
        public static void swap(ref string x,ref string y)
        {
            string temp;
            temp = x;
            x = y;
            y = temp;
        }
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now.AddDays(2);
            Console.WriteLine("\nBefore swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");
            swap(ref date1, ref date2);
            Console.WriteLine("\nAfter swapping");
            Console.WriteLine($"Date1:{date1} \nDate2:{date2}");
            Console.ReadLine();
        }
    }
}

