namespace LinkedList
{
    public class Node
    {
        public  int element;
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
            Console.WriteLine();

        }
        public void addFirst(int e)
        {
            Node newest = new Node(e, null);
            if(isEmpty())
            {
                head = newest;
                tail = newest;

            }
            else
            {
                newest.next = head;
                head = newest;
            }
            size = size + 1;
        }

        public void AddAny(int e,int position)
        {
            if(position< 0 || position > size)
            {
                Console.WriteLine("Invalid postion");
                return;
            }
            
            Node newest = new Node(e,null);
            
            Node p = head;
            int i = 1;
            while(i < position -1)
            {
                p = p.next;
                i = i + 1;
            }
            newest.next = p.next;
            p.next = newest;
            size = size + 1;
        }
        static void Main(string[] args)
        {
            Program l=new Program();
            //l.addLast(10);
            //l.addLast(20);
            //l.addLast(13);
            Console.WriteLine("\nSize: " + l.length());
            //l.addLast(67);
            //l.addLast(8);
            //l.Display();
            Console.WriteLine("\nSize: " + l.length());
            //l.addFirst(100);
            //l.Display();
            l.AddAny(39,0);
            l.Display();
            Console.WriteLine("\nSize: " + l.length());
            Console.ReadLine();
        }
    }
}

updated code for this situation if u want to add at the first by comenting other 

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
            Console.WriteLine();

        }
        public void addFirst(int e)
        {
            Node newest = new Node(e, null);
            if(isEmpty())
            {
                head = newest;
                tail = newest;

            }
            else
            {
                newest.next = head;
                head = newest;
            }
            size = size + 1;
        }

        public void AddAny(int e,int position)
        {
            if(position< 0 || position > size)
            {
                Console.WriteLine("Invalid postion");
                return;
            }
            if (position == 0)
            {
                addFirst(e);
                return;
            }
  
            if (position == size)
            {
                addLast(e);
                return;
            }
            Node newest = new Node(e,null);
            
            Node p = head;
            int i = 1;
            while(i < position -1)
            {
                p = p.next;
                i = i + 1;
            }
            newest.next = p.next;
            p.next = newest;
            size = size + 1;
        }
        static void Main(string[] args)
        {
            Program l=new Program();
            //l.addLast(10);
            //l.addLast(20);
            //l.addLast(13);
            Console.WriteLine("\nSize: " + l.length());
            //l.addLast(67);
            //l.addLast(8);
            //l.Display();
            Console.WriteLine("\nSize: " + l.length());
            //l.addFirst(100);
            //l.Display();
            l.AddAny(39,0);
            l.Display();
            Console.WriteLine("\nSize: " + l.length());
            Console.ReadLine();
        }
    }
}
updaated code 
--------------
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
            Console.WriteLine();

        }
        public void addFirst(int e)
        {
            Node newest = new Node(e, null);
            if(isEmpty())
            {
                head = newest;
                tail = newest;

            }
            else
            {
                newest.next = head;
                head = newest;
            }
            size = size + 1;
        }

        public void AddAny(int e,int position)
        {
            if(position< 0 || position > size)
            {
                Console.WriteLine("Invalid postion");
                return;
            }
            if (position == 0)
            {
                addFirst(e);
                return;
            }

            if (position == size)
            {
                addLast(e);
                return;
            }
            Node newest = new Node(e,null);
            
            Node p = head;
            int i = 1;
            while(i < position -1)
            {
                p = p.next;
                i = i + 1;
            }
            newest.next = p.next;
            p.next = newest;
            size = size + 1;
        }
        public int removeFirst()
        {
            if(isEmpty())
            {
                Console.WriteLine("List is empty");
                return -1;
            }
            
            
                int e = head.element;
                head = head.next;
                size = size - 1;
                if(isEmpty())
                {
                    tail = null;
                }
                return e;

            
            
        }
        static void Main(string[] args)
        {
            Program l=new Program();
            l.addLast(10);
            l.addLast(20);
            l.addLast(13);
            Console.WriteLine("\nSize: " + l.length());
            l.addLast(67);
            l.addLast(8);
            l.Display();
            Console.WriteLine("\nSize: " + l.length());
            l.addFirst(100);
            l.Display();
            l.AddAny(39,0);
            l.Display();
           int element= l.removeFirst();
            Console.WriteLine($"\n removed elememt {element}:");
            l.Display();
            Console.WriteLine("\nSize: " + l.length());
            Console.ReadLine();
        }
    }
}


