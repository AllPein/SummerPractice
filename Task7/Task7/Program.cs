using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    class Program
    {
        //Неравенство Макмиллана
        static bool CheckLengths(int[] lengths) 
        {
            double sum = 0;
            foreach (var num in lengths)
                sum += 1 / Math.Pow(2, num);

            return sum <= 1;
        }
        //Функция для проверки валидности введенных длин
        static int[] CheckInput(string[] inp)
        {
            int x;
            int[] lengths = new int[inp.Length];
            int index = 0;
            foreach (var elem in inp)
            {
                bool ok = int.TryParse(elem, out x);
                if (ok)
                {
                    lengths[index] = x;
                }
                else
                {
                    return new int[] { };
                }
                index++;
            }
            return lengths;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длины кодовых слов через пробел: ");
            bool isOk;
            string[] lengths;
            int[] lengthsOfWords = {};
            do
            {
                lengths = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (CheckInput(lengths).Length > 0)
                    lengthsOfWords = CheckInput(lengths);
                else
                {
                    Console.WriteLine("Вы ввели некорректные значения длины!");
                    break;
                }
                isOk = CheckLengths(lengthsOfWords);
                if (!isOk)
                    Console.WriteLine("Ошибка! Введенные длины кодовых слов не прошли проверку по неравенству Макмиллана. Повторите ввод.");
            } while (!isOk);

            if (lengthsOfWords.Length > 0)
            {
                lengthsOfWords = lengthsOfWords.OrderBy(num => num).ToArray();

                Tree tree = new Tree();

                foreach (int length in lengthsOfWords)
                    Tree.GeneratePoint(tree.root, 0, length);

                Tree.words = new List<string>(lengthsOfWords.Length);
                Tree.GenerateCode(tree.root, "");

                Console.Write("Префиксный двоичный код: ");
                foreach (string word in Tree.words)
                    Console.Write($"{word} ");
                Console.WriteLine();
                
            }
            
        }
    }
}