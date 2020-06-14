using System;
using System.Collections.Generic;

namespace Task08
{
    // Ребро
    public class Point
    {
        // Номера вершин, которые соединяют ребро
        public int V1;
        public int V2;

        public Point(int v1, int v2)
        {
            V1 = v1;
            V2 = v2;
        }
    }
    
    class Program
    {
        public static void Main()
        {
            List<Point> edges = new List<Point>
            {
                new Point(0, 1),
                new Point(1, 2),
                new Point(2, 3),
                new Point(0, 3)
            };

            int verticiesCount = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            string result = ChainsSearch(verticiesCount, edges, k);
            
            Console.WriteLine(result);
        }

        static string ChainsSearch(int verticiesCount, List<Point> edges, int k)
        {
            if (verticiesCount < 1)
            {
                Console.WriteLine("Число вершин должно быть натуральным числом!");
                Environment.Exit(0);
            } 
            if (k < 1)
            {
                Console.WriteLine("Число K должно быть натуральным числом!");
                Environment.Exit(0);
            }
            foreach (var edge in edges)
            {
                if (edge.V1 < 0 || edge.V2 < 0 || edge.V1 >= verticiesCount || edge.V2 >= verticiesCount)
                {
                    Console.WriteLine($"Описание вершин графа должно быть в промежтке 0 .. {verticiesCount-1}");
                    Environment.Exit(0);
                }
            }
            
            var colors = new int[verticiesCount];
            for (int i = 0; i < verticiesCount - 1; i++)
            {
                for (int j = i + 1; j < verticiesCount; j++)
                {
                    for (int z = 0; z < verticiesCount; z++)
                    {
                        colors[k] = 1;
                    }
                    var chain = DFS(i, j, edges, colors, (i + 1).ToString());
                    if (chain != null)
                    {
                        var chainVerticies = chain.Split('-');
                        if (chainVerticies.Length == k) return chain;
                    }
                }
            }

            return null;
        }
        
        static string DFS(int u, int endVertex, List<Point> edges, int[] colors, string chain)
        {
            if (u != endVertex)
                colors[u] = 2;
            else
                return chain;

            
            foreach (var edge in edges)
            {
                if (colors[edge.V2] == 1 && edge.V1 == u)
                {
                    var result = DFS(edge.V2, endVertex, edges, colors, chain + "-" + (edge.V2 + 1).ToString());
                    colors[edge.V2] = 1;
                    return result;
                }
                else if (colors[edge.V1] == 1 && edge.V2 == u)
                {
                    var result = DFS(edge.V1, endVertex, edges, colors, chain + "-" + (edge.V1 + 1).ToString());
                    colors[edge.V1] = 1;
                    return result;
                }
            }
            return null;
        } 
    }
}