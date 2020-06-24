using System;
using System.Collections.Generic;

namespace Task08
{
    // Класс, описывающий ребро
    public class Edge
    {
        // Номера вершин, которые соединяет ребро
        public int V1;
        public int V2;

        public Edge(int v1, int v2)
        {
            V1 = v1;
            V2 = v2;
        }
    }
    class Program
    {
        public static List<string> chains = new List<string>();

        public static void Main()
        {
            List<Edge> edges = new List<Edge>
            {
                new Edge(1, 2),
                new Edge(2, 3),
                new Edge(1, 3),
                new Edge(3, 4)
            };

            int verticiesCount = Input("Введите количество вершин в графе: ");
            int k = Input("Введите целое число K: ");
            
            ChainsSearch(verticiesCount, edges, k);
            int index = 1;
            foreach (var chain in  chains)
            {
                if (index <= k)
                {
                    Console.WriteLine(chain);

                }
                else
                {
                    break;
                }
                index++;
            }
        }

        //Метод поиска всех простых цепей в графе
        static void ChainsSearch(int verticiesCount, List<Edge> edges, int k)
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
                if (edge.V1 < 0 || edge.V2 < 0 || edge.V1 > verticiesCount || edge.V2 > verticiesCount)
                {
                    Console.WriteLine($"Описание вершин графа должно быть в промежутке 0 .. {verticiesCount - 1}");
                    Environment.Exit(0);
                }
            }
            
            var colors = new int[verticiesCount + 1];
            
            for (int i = 0; i < verticiesCount; i++)
            {
                for (int j = i + 1; j < verticiesCount; j++)
                {
                    for (int z = 0; z < verticiesCount; z++)
                    {
                        colors[z] = 1;
                    }
                    DFS(i, j, edges, colors, (i).ToString());
                }
            }

            
        }
        //Метод поиска в глубину
        static void DFS(int u, int endVertex, List<Edge> edges, int[] colors, string chain)
        {
            if (u != endVertex)
                colors[u] = 2;
            else
            {
                chains.Add(chain);
                return;
            }
            
            foreach (var edge in edges)
            {
                if (colors[edge.V2] == 1 && edge.V1 == u)
                {
                    DFS(edge.V2, endVertex, edges, colors, chain + "-" + (edge.V2 + 1).ToString());
                    colors[edge.V2] = 1;
                }
                else if (colors[edge.V1] == 1 && edge.V2 == u)
                {
                    DFS(edge.V1, endVertex, edges, colors, chain + "-" + (edge.V1 + 1).ToString());
                    colors[edge.V1] = 1;
                }
            }
        }
        //Функция для проверки ввода
        static int Input(string msg)
        {
            Console.Write(msg);
            int x;
            bool ok = int.TryParse(Console.ReadLine(), out x);
            if (!ok)
            {
                Console.WriteLine("Введите число!");
                return Input(msg);
            }
            return x;
        }
    }
}