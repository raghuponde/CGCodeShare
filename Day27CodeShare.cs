
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
        public int length()
        {
           return size;
        }
        public bool isEmpty()
        {
            return size == 0;
        }

        public void addLast(int e)
        {
            Node newest = new Node(e, null);
            if(isEmpty())
            {
                head=newest;
            }
            else
            {
                   tail.next=newest;
            }
            tail=newest;
            size=size+1;
        }
        public void Display()
        {
            Node p = head;
            while (p!=null)
            {
                Console.Write(p.element+"----> ");
                p=p.next;

            }

        }
        static void Main(string[] args)
        {
            
        }
    }
}
