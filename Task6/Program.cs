using System;
using System.Collections.Generic;

namespace Task6
{
    class Program
    {
        public static double[] cache = new double[3];
        public static List<double> gt = new List<double>();
        public static List<double> nums = new List<double>();
        public static double a1, a2, a3, L;
        public static int M, N;
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != 6 || !CheckDouble(values[0]) || !CheckDouble(values[1]) || !CheckDouble(values[2]) ||
                !CheckDouble(values[3]) || !CheckDouble(values[4])
                || !CheckDouble(values[5]))
            {
                Console.WriteLine("Ошибка ввода!");
                Environment.Exit(0);
            }
            a1 = double.Parse(values[0]);
            a2 = double.Parse(values[1]);
            a3 = double.Parse(values[2]);
            M = int.Parse(values[3]);
            N = int.Parse(values[4]);
            L = double.Parse(values[5]);

            cache = new[] { a1, a2, a3 };
            nums.Add(a1);
            nums.Add(a2);
            nums.Add(a3);

            for (int i = 0; i < 3; i++)
            {
                if (nums[i] > L)
                    gt.Add(nums[i]);
            }
            
            Calculate(ref cache, N);
            Console.WriteLine($"Причина остановки: найдены первые {N} элемента(-ов) последовательности");
            foreach (var x in nums)
            {
                Console.Write($"{x} ");
            }
        }
        //Функция для расчета последовательности с сохранением 3-х ее членов
        static double Calculate(ref double[] cache, int i)
        {
            double ak;
            if (i != 4)
            {
                double tmp = Calculate(ref cache, i - 1);
                cache[0] = cache[1];
                cache[1] = cache[2];
                cache[2] = tmp;
            }
            
            ak = (7/3 * cache[2] + cache[1])/2 * cache[0];
    
            if (gt.Count >= M - 1)
            {
                Console.WriteLine($"Причина остановки: найдены первые {M} элемента(-ов), большие числа {L}");
                foreach (var x in gt)
                {
                    Console.Write($"{x} ");
                }

                Environment.Exit(0);
            }
            
            if (ak > L)
            {
                gt.Add(ak);
            }

            nums.Add(ak);

            
            return ak;
        }
        //Функция для проверки правильности введенного числа
        static bool CheckDouble(string str)
        {
            double x;
            return double.TryParse(str, out x);
        }
    }
}
