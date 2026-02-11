
namespace LinkedList
{
    public class Node
    {
        public int element;
        public Node next;
        public Node(int e ,Node n)
        {
                element = e;
                next = n;
        }
    }
     class Program
    {
        private Node head;
        private Node tail;
        private int size;

        public Program()
        {
            head = null;
            tail = null;
            size = 0;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
