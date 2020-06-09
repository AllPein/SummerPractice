using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int x, y;
            bool okX = int.TryParse(values[0], out x);
            bool okY = int.TryParse(values[1], out y);
            if (!okX || !okY)
                Environment.Exit(0);

            if (y <= 1 - Math.Pow(x, 2) && Math.Pow(x, 2) + Math.Pow((y - 1), 2) <= 1)
                Console.WriteLine($"u = {x - y}");
            else
                Console.WriteLine($"u = {x * y + 7}");
        }
    }
}
