using System;
using System.IO;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = File.ReadAllText("INPUT.txt").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int w;
            int h;

            bool okW = int.TryParse(values[0], out w);
            bool okH = int.TryParse(values[1], out h);

            if (!okW || !okH)
                Environment.Exit(0);


            int answer = Solve(w, h);

            File.WriteAllText("OUTPUT.txt", answer.ToString());
        }
        public static int Solve(int w, int h)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 1; i <= w; i++)
            {
                sum1 += i;
            }
            for (int i = 1; i <= h; i++)
            {
                sum2 += i;
            }
            return sum1 * sum2;
        }
    }
}
