
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
            data[top] = e;
            top = top + 1;
        }
        public int pop()
        {
            if(isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            int e= data[top];
            top = top - 1;
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
            Console.WriteLine("Hello, World!");
        }
    }
}
