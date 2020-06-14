using System;
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

        public void Insert(TreeNode node)
        {
            
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

        public Arr Transform(int compareCount, List<int> elements = null)
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

            return new Arr(elements.ToArray(), 0, compareCount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 5, 4, 3, 2, 1 };
            int[] arr3 = { 4, 2, 1, 3, 5 };
            
            Console.WriteLine($"1. Отсортированный по возрастанию массив: {string.Join(" ", arr1)}");
            Console.WriteLine($"2. Отсортированный по убыванию массив: {string.Join(" ", arr2)}");
            Console.WriteLine($"3. Неотсортированный массив: {string.Join(" ", arr3)} \n");
            
            Console.WriteLine("Сортировка бинарным деревом: ");
            Console.WriteLine($"1.{TreeSort(arr1).ToString()}");
            Console.WriteLine($"2.{TreeSort(arr2).ToString()}");
            Console.WriteLine($"3.{TreeSort(arr3).ToString()} \n");

            Console.WriteLine("Сортировка пузырьком: ");
            Console.WriteLine($"1.{BubbleSort(arr1).ToString()}");
            Console.WriteLine($"2.{BubbleSort(arr2).ToString()}");
            Console.WriteLine($"3.{BubbleSort(arr3).ToString()} \n");

        }
        private static Arr TreeSort(int[] array)
        {
            var treeNode = new TreeNode(array[0]);
            int compareCount = 0;
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
                compareCount += 2;
            }
                
            return treeNode.Transform(compareCount);
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