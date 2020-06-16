using System;
using System.IO;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = File.ReadAllText("INPUT.txt").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            Int64 w;
            Int64 h;

            bool okW = Int64.TryParse(values[0], out w);
            bool okH = Int64.TryParse(values[1], out h);

            if (!okW || !okH)
                Environment.Exit(0); 

    
            Int64 answer = Solve(w, h);
            
            File.WriteAllText("OUTPUT.txt", answer.ToString());
        }
        //Функция для находении суммы чисел от 1 до N
        static Int64 FindSum(Int64 n)        
        {
            Int64 sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }
        //Функция для расчета количества прямоугольников
        static Int64 Solve(Int64 w, Int64 h)
        {
            Int64 sum1 = FindSum(w);
            Int64 sum2 = FindSum(h);
            return sum1 * sum2;
        }
    }
}
