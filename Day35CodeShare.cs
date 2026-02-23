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
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void inorder(Node temproot)
        {
            if (temproot != null)
            {
                inorder(temproot.left);
                Console.Write(temproot.element + " ");
                inorder(temproot.right);
            }
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
            Node n = new Node(e, null, null);
            if (root != null)
            {
                if (e < temp.element)
                    temp.left = n;
                else
                    temp.right = n;
            }
            else
            {
                root = n;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree B = new BinarySearchTree();
            B.insert(B.root, 50);
            B.insert(B.root, 50);
            B.insert(B.root, 30);
            B.insert(B.root, 80);
            B.insert(B.root, 10);
            B.insert(B.root, 40);
            B.insert(B.root, 60);
            B.insert(B.root, 90);
            Console.WriteLine("Inorder Traversal");
            B.inorder(B.root);
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
