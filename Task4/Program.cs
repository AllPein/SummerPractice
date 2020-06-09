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

            double xOld = x1;
            while (Math.Abs(xOld - x2) >= e) 
            {
                xOld = x2;
                x2 = x2 - f(x2) / (f(x2) - f(x1)) * (x2 - x1);
                x1 = xOld;
            }

            Console.WriteLine(x2);
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
