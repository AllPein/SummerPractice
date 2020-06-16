using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Зашифрованная строка: ");
            Console.WriteLine(encrypted);
            Console.WriteLine("Расшифрованная строка: ");
            Console.WriteLine(decrypted);
        }
        //Создание строки из матрицы
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
        //Создание матрицы из строки
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
        //Кодирование строки
        static string Encrypt(char[] arr)
        {
            char[,] matr = MakeMatr(arr);
            string encryptedString = "";
            int iInd = matr.GetLength(0)/2;
            int jInd = matr.GetLength(0)/2;    

            int iStep = 1;
            int jStep = 1;

            for(int i = 0; i < 11; i++){
                for (int h = 0; h < i; h++) encryptedString += matr[iInd, jInd += jStep];
                for (int v = 0; v < i; v++) encryptedString += matr[iInd += iStep, jInd];
                jStep = -jStep;
                iStep = -iStep;     
            }   
            for (int h = 0; h < matr.GetLength(0) - 1; h++) 
                encryptedString += matr[iInd, jInd += jStep];
            
            return encryptedString;
        }
        //Расшифровка строки
        static string Decrypt(string encrypted)
        {
            char[,] matr = new char[11, 11];
            int iInd = matr.GetLength(0)/2;
            int jInd = matr.GetLength(0)/2;
            int index = 0;
            int iStep = 1;
            int jStep = 1;

            for(int i = 0; i < 11; i++){
                for (int h = 0; h < i; h++)
                {
                    matr[iInd, jInd += jStep] = encrypted[index];
                    index++;
                }

                for (int v = 0; v < i; v++)
                {
                    matr[iInd += iStep, jInd] = encrypted[index];
                    index++;
                }
                jStep = -jStep;
                iStep = -iStep;
            }
        
            for (int h = 0; h < matr.GetLength(0) - 1; h++)
            {
                matr[iInd, jInd += jStep] = encrypted[index];
                index++;
            } 
            
            string text = MakeString(matr);
            return text;
        }
    }
}
