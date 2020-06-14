using System;
using System.Collections.Generic;
namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            if (str.Length < 121) 
                Environment.Exit(0);

            string text = str.Substring(0, 121);
            char[] array = text.ToCharArray();

            string encrypted = Encrypt(array);
            string decrypted = Decrypt(encrypted);
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
        }

        public static string MakeString(char[,] matr)
        {
            string txt = "";
            for(int i= 0; i< matr.GetLength(0); i++)
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                txt += matr[i, j].ToString();
            }

            return txt;
        }

        public static char[,] MakeMatr(char[] array)
        {
            char[,] matr = new char[11, 11];

            for(int i= 0; i< matr.GetLength(0); i++)
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                matr[i, j] = array[11 * i + j];
            }

            return matr;
        }
        static string Encrypt(char[] arr)
        {
            char[,] matr = MakeMatr(arr);
            string encryptedString = "";
            int min = 0;
            int max = 10;
            do
            {
                for (int i = min; i <= max; i++)
                    encryptedString = matr[min, i].ToString() + encryptedString;
                
                for (int i = min + 1; i <= max; i++)
                    encryptedString = matr[i, max].ToString() + encryptedString;
                
                for (int i= max - 1; i >= min; i--)
                    encryptedString = matr[max, i].ToString() + encryptedString;
                
                for (int i = max - 1; i >= min + 1; i--)
                    encryptedString = matr[i, min].ToString() + encryptedString;
                min++;
                max--;
            } while (encryptedString.Length != 121);
            
            return encryptedString;
        }
        static string Decrypt(string encrypted)
        {
            char[,] matr = new char[11, 11];
            int min = 0;
            int max = 10;
            int s = 120;
            do
            {
                for (int i = min; i <= max; i++)
                {
                    matr[min, i] = encrypted[s];
                    s--;
                }
                for (int i = min + 1; i <= max; i++)
                {
                    matr[i, max] = encrypted[s];
                    s--;
                }
                for (int i = max - 1; i >= min; i--)
                {
                    matr[max, i] = encrypted[s];
                    s--;
                }
                for (int i = max - 1; i >= min + 1; i--)
                {
                    matr[i, min] = encrypted[s];
                    s--;
                }
                min++;
                max--;
            } while (s != -1);
            
            string text = MakeString(matr);
            return text;
        }
    }
}
