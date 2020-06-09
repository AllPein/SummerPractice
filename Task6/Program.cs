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

            if (values.Length != 6 || !CheckDouble(values[0]) || !CheckDouble(values[1]) || !CheckDouble(values[2]) || !CheckDouble(values[3]) || !CheckDouble(values[4])
                || !CheckDouble(values[5]))
                Environment.Exit(0);
           
            a1 = double.Parse(values[0]);
            a2 = double.Parse(values[1]);
            a3 = double.Parse(values[2]);
            M = int.Parse(values[3]);
            N = int.Parse(values[4]);
            L = double.Parse(values[5]);

            double ak = 0;
            double[] gt = new double[N];
            double[] nums = new double[N];

            int index = 0;
            while (nums.Length < N && gt.Length < M)
            {
                if (a3 != 0)
                    ak = (7 / 3 * a1 + a2) / (2 * a3);
                a3 = ak;
                Switch(ref a1, ref a2);
                if (ak > L)
                {
                    gt[index] = ak;
                }
                nums[index] = ak;
                index++;
            }

            foreach (var x in nums)
            {
                Console.Write($"{x} ");
            }
        }
        static bool CheckDouble(string str)
        {
            double x;
            return double.TryParse(str, out x);
        }
        static void Switch(ref double a, ref double b)
        {
            double tmp = a;
            a = b;
            b = tmp;
        }
    }
}
