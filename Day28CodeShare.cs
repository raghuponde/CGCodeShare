namespace StacksUsingArrays
{
    class StackArray
    {
        int[] data;

        int top;

        public StackArray(int n)
        {
               data=new int[n];
              top = -1;
        }
        public int length()
        {
            return top+1;
        }
        public bool isEmpty()
        {
            return top==-1;
        }   
        public bool isFull()
        {
            return top == data.Length;
        }

        public void push(int e)
        {
            if(isFull())
            {
                Console.WriteLine("Stack is full");
                return;

            }
            top = top + 1;
            data[top] = e;
            
        }
        public int pop()
        {
            if(isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            int e= data[top];
            top = top-1 ;
            return e;

        }

        public int peek()
        {
            if(isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            return data[top];
        }
        public void display()
        {
            for(int i=top;i>=0;i--)
            {
                Console.WriteLine(data[i]);
            }
        }   
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           StackArray s = new StackArray(10);
            s.push(10);
            s.push(20);
            s.display();
            Console.WriteLine($"Size: {s.length()}")    ;
            Console.WriteLine($"Eelement poped: {s.pop()}")    ;
            Console.WriteLine($"Is empty:{s.isEmpty()} ");
            Console.WriteLine($"Eelement poped: {s.pop()}");
            Console.WriteLine($"Is empty:{s.isEmpty()} ");
            s.push(23);
            s.push(45);
            s.display();
            Console.WriteLine($"Eelement toped: {s.peek()}");
            s.display();
            Console.ReadLine();

        }
    }
}


------------------
namespace QueueUsingArrays
{

    class QueuesArray
    {
        int[] data;
        int front;
        int rear;
        int size;

        public QueuesArray(int n)
        {
              data = new int[n];
            front = 0;
            rear = 0;
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
        public bool isFull()
        {
            return size == data.Length;
        }
        public void enqueue(int e)
        {
            if(isFull())
            {
                Console.WriteLine("Queue is full");
                return;
            }
            else
            {
                data[rear] = e;
                rear = (rear + 1);
                size = size + 1;

            }
        }
        public int dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }
            else
            {
                int e = data[front];
                front = (front + 1);
                size = size - 1;
                return e;
            }
        }
        public void display()
        {
           for(int i=front;i<rear;i++)
            {
                   Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            QueuesArray q = new QueuesArray(10);
            q.enqueue(10);
            q.enqueue(20);
            q.display();
            Console.WriteLine($"Size of queue is {q.length()}") ;
            Console.WriteLine($"element removed : {q.dequeue()}")   ;
            Console.WriteLine($"Is empty :{q.isEmpty()}");
            Console.WriteLine($"element removed : {q.dequeue()}");
            Console.WriteLine($"Is empty :{q.isEmpty()}");
            q.enqueue(34);
            q.enqueue(56);
            q.display();
            Console.WriteLine($"Size of queue is {q.length()}");

        }
    }
}


Linq to File 
-------------
namespace LinqToFilesDemo
{

    public class MyFileInfo
    {
        public string Name { get; set; }
        public long  length { get; set; }
        public DateTime CreationTime { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var files =  new DirectoryInfo(@"C:\Windows").GetFiles();
            var query = from file in files
                        where file.Length > 10000
                        orderby file.Length
                        select new MyFileInfo
                        {
                            Name = file.Name,
                            length = file.Length,
                            CreationTime=file.CreationTime
                        };


            foreach(var file1 in query)
            {
                Console.WriteLine($"The {file1.Name} constains {file1.length} and was creeated at {file1.CreationTime}");

            }
            Console.ReadLine();
        }
    }
}


imagein i had commented the user defined class

    namespace LinqToFilesDemo
{

    //public class MyFileInfo
    //{
    //    public string Name { get; set; }
    //    public long  length { get; set; }
    //    public DateTime CreationTime { get; set; }
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            var files =  new DirectoryInfo(@"C:\Windows").GetFiles();
            var query = from file in files
                        where file.Length > 10000
                        orderby file.Length

                        select new // here anonmyouse class 
                        {
                            Name = file.Name,
                            length = file.Length,
                            CreationTime=file.CreationTime
                        };


            foreach(var file1 in query)
            {
                Console.WriteLine($"The {file1.Name} constains {file1.length} and was creeated at {file1.CreationTime}");

            }
            Console.ReadLine();
        }
    }
}
Then i have to write rhe code as above here anonymous  class is coming


namespace LinqToFilesDemo
{

    //public class MyFileInfo
    //{
    //    public string Name { get; set; }
    //    public long  length { get; set; }
    //    public DateTime CreationTime { get; set; }
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            var files =  new DirectoryInfo(@"C:\Windows").GetFiles();
            var query = from file in files
                        where file.Length > 10000
                        orderby file.Length
                        select file;
       // here above query i can display all the proeprties if i write like this ...we cannot project more than one column in using above syntax 
            //so we have to follow ...select new syntax 

            
                        //select new // here anonmyouse class 
                        //{
                        //    Name = file.Name,
                        //    length = file.Length,
                        //    CreationTime=file.CreationTime
                        //};


            foreach(var file1 in query)
            {
                Console.WriteLine($"The {file1.Name} constains {file1.Length} and was creeated at {file1.CreationTime}");

            }
            Console.ReadLine();
        }
    }
}
