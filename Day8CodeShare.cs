
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
            Console.WriteLine("Hello, World!");
        }
    }
}
