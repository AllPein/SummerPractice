using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            double e = Input("Введите точность e: ");
            double x1 = Input("Введите x1: ");
            double x2 = Input("Введите x2: ");

            double x = Solve(x1, x2, e);
            Console.WriteLine(x);
        }
        public static double Solve(double xPrev, double xCur, double e)
        {
            double xNext = 0;
            double tmp;
            do
            {
                tmp = xNext;
                xNext = xCur - f(xCur) * (xPrev - xCur) / (f(xPrev) - f(xCur));
                xPrev = xCur;
                xCur = tmp;
            } while (Math.Abs(xNext - xCur) > e);
 
            return xNext;
        }
        static double f(double x)
        {
            return Math.Pow(x, 2) - 1.3 * Math.Log(x + 0.5) - 2.8 * x + 1.15;
        }
        static double Input(string msg)
        {
            Console.Write(msg);
            double x;
            bool ok = double.TryParse(Console.ReadLine(), out x);
            if (!ok)
            {
                Console.WriteLine("Введите число!");
                return Input(msg);
            }
            return x;
        }
    }
}
