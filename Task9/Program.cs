using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyLinkedList<int>(5);
            Console.WriteLine("DEBUG:: LIST1");
            foreach (var el in list)
                Console.Write($"{el} ");

            list.RemoveByKey(0);

            
            Console.WriteLine("\nDEBUG:: LIST2");

                Console.WriteLine(list.ToString());

            Console.WriteLine(list.FindElem(9));
        }
        
    }
}
