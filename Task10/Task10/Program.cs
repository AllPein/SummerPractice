using System;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tr = new Tree(3);
            
            Tree.Node node = new Tree.Node(4);
            tr.Insert(ref node, 5);
            tr.Insert(ref node, 6);
           
            Tree.Run(node, 0);
        }
    }
}