using System.Collections.Generic;

namespace Task7
{
    class Node
    {
        public int Number;
        public Node Left { get; set; } 
        public Node Right { get; set; } 
        public bool IsEnd { get; set; } 

        public Node(int number)
        {
            this.Number = number;
            this.Left = this.Right  = null;
            this.IsEnd = false;
        }
    }
    class Tree
    {
        public Node root;
        public static List<string> words;
        public Tree()
        {
            this.root = new Node(-1);
        }
        public static void GeneratePoint(Node p, int currentLength, int length)
        {
            if (currentLength != length - 1)
            {
                if (p.Left != null && p.Left.IsEnd == false)
                    GeneratePoint(p.Left, currentLength + 1, length);
                else if (p.Left == null)
                {
                    p.Left = new Node(0);
                    GeneratePoint(p.Left, currentLength + 1, length);
                }

                else if (p.Right != null && p.Right.IsEnd == false)
                    GeneratePoint(p.Right, currentLength + 1, length);
                else if (p.Right == null)
                {
                    p.Right = new Node(1);
                    GeneratePoint(p.Right, currentLength + 1, length);
                }
            }
            else
            {
                if (p.Left == null || p.Left.IsEnd == false)
                {
                    p.Left = new Node(0);
                    p.Left.IsEnd = true;
                }
                else if (p.Right == null || p.Right.IsEnd == false)
                {
                    p.Right = new Node(1);
                    p.Right.IsEnd = true;
                }
            }
        }
        public static void GenerateCode(Node p, string word)
        {
            if (p != null && !p.IsEnd)
            {
                word += p.Number;
                GenerateCode(p.Left, word);
                GenerateCode(p.Right, word);
            }
            else if (p != null && p.IsEnd)
            {
                word += p.Number;
                word = word.Remove(0, 2);
                words.Add(word);
            }
        }
    }
}