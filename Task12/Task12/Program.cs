﻿using System;
using System.Collections.Generic;
namespace Task12
{
    public class Arr
    {
        public int chCount, compCount;
        public int[] arr;
        
        public Arr(int[] arr, int chCount, int compCount)
        {
            this.arr = arr;
            this.chCount = chCount;
            this.compCount = compCount;
        }

        public override string ToString()
        {
            string output = "Отсортированный массив: \n";
            foreach (var elem in this.arr)
                output += elem + " ";
            
            output += "\nКоличество перестановок: " + this.chCount;
            output += "\nКоличество сравнений: " + this.compCount;

            return output;
        }
    }
    public class TreeNode
    {
        public TreeNode(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public Arr Insert(TreeNode node, int chCount, int compCount)
        {
            
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node, chCount + 1, compCount + 1);
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
                    Right.Insert(node, chCount + 1, compCount + 1);
                }
            }
            return new Arr(new int[]{}, chCount, compCount);
        }

        public Arr Transform(Arr a, List<int> elements = null)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }

            if (Left != null)
            {
                Left.Transform(a, elements);   
            }

            elements.Add(Data);

            if (Right != null)
            {              
                Right.Transform(a, elements);
            }

            return new Arr(elements.ToArray(), a.chCount, a.compCount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());

            var a = new int[n];
            var random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(0, 100);
            }

            Console.WriteLine("Random Array: {0}", string.Join(" ", a));

            Console.WriteLine(TreeSort(a).ToString());

            Arr sorted = BubbleSort(a);
            
            Console.WriteLine(sorted.ToString());

        }
        private static Arr TreeSort(int[] array)
        {
            var treeNode = new TreeNode(array[0]);
            Arr a = new Arr(new int[]{}, 0, 0);
            for (int i = 1; i < array.Length; i++)
            {
                a = treeNode.Insert(new TreeNode(array[i]), 0, 0);
            }

            return treeNode.Transform(a);
        }

        private static Arr BubbleSort(int[] arr)
        {
            int tmp;
            int chCount = 0;
            int compCount = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    compCount++;
                    if (arr[i] > arr[j])
                    {
                        tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;

                        chCount++;
                    }
                }
            }
            return new Arr(arr, chCount, compCount);
        }
    }
}