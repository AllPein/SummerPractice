using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int M, N;
            double a1, a2, a3, L;

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

            double ak = 0;
            double[] gt = new double[M];
            double[] nums = new double[N];

            int gtIndex = 0;
            for (int i = 1; i <= N; i++)
            {
                if (gtIndex == gt.Length)
                    break;
                
                ak = a(a1, a2, a3, i);
                if (ak > L)
                {
                    gt[gtIndex] = ak;
                    gtIndex++;
                }
                nums[i - 1] = ak;
            }

            if (gtIndex == gt.Length)
            {
                Console.WriteLine($"Причина остановки: найдены первые {M} элемента(-ов), большие числа {L}");
                foreach (var x in gt)
                {
                    Console.Write($"{x} ");
                }
            }
            else
            {
                Console.WriteLine($"Причина остановки: найдены первые {N} элемента(-ов) последовательности");
                foreach (var x in nums)
                {
                    Console.Write($"{x} ");
                }
            }
            
        }
        static double a(double a1, double a2, double a3, int i)
        {
            double ak;
            if (i == 1) ak = a1;
            else if (i == 2) ak = a2;
            else if (i == 3) ak = a3;
            else
            {
                ak = (7/3 * a(a1, a2, a3, i - 1) + a(a1, a2, a3, i - 2))/2 * a(a1, a2, a3, i - 3);
            }
            return ak;
        }
        static bool CheckDouble(string str)
        {
            double x;
            return double.TryParse(str, out x);
        }
    }
}
