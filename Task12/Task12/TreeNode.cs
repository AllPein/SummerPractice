using System.Collections.Generic;

namespace Task12
{
    public class TreeNode
    {
        public int compareCount = 0;
        public TreeNode(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public void Insert(TreeNode node)
        {
            compareCount++;
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        public static void Count(ref int compareCount, TreeNode node)
        {
            if (node != null)
            {
                compareCount += node.compareCount;
                Count(ref compareCount, node.Left);
                Count(ref compareCount, node.Right);
            }
        }
       
        public ShowResults Transform(int compareCount, List<int> elements = null)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }
            if (Left != null)
            {
                Left.Transform(compareCount, elements);   
            }

            elements.Add(Data);

            if (Right != null)
            {              
                Right.Transform(compareCount, elements);
            }

            return new ShowResults(elements.ToArray(), 0, compareCount);
        }
    }
}