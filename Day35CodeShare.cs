
namespace TreeDemo
{

    class Node
    {
        public int element;
        public Node left;
        public Node right;

        public Node(int e,Node l,Node r)
        {
            element = e;
            left = l;
            right = r;
        }
    }

    class BinarySearchTree
    {
        Node root;
        public BinarySearchTree()
        {
            root = null;
        }

        public void insert(Node temproot,int e)
        {
            Node temp = null;
            while(temproot!=null)
            {
                temp = temproot;
                if (e == temproot.element)
                    return;
                else if (e < temproot.element)
                    temproot = temproot.left;
                else if (e > temproot.element)
                    temproot = temproot.right;

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
