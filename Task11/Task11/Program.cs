using System;
using System.Collections.Generic;
namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            if (text.Length != 121) 
                Environment.Exit(0);
            char[] matr = text.ToCharArray();

            var asnwer = Spiral(matr);
            PrintList(asnwer);
            
        }
        public static List<char> Spiral(char[] matr)
        {
            char[,] array = new char[11, 11];

            List<char> answer = new List<char>();
            for(int i= 0; i<array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = matr[11 * i + j];
            }
            
            int iInd = array.GetLength(0)/2;
            int jInd = array.GetLength(0)/2;    

            int iStep = 1;
            int jStep = 1;

            Console.Write(array[iInd,jInd] + "");                  
            for(int i = 0; i < 11; i++){
                for (int h = 0; h < i; h++) answer.Add(array[iInd, jInd += jStep]);
                for (int v = 0; v < i; v++) answer.Add(array[iInd += iStep, jInd]);
                jStep = -jStep;
                iStep = -iStep;     
            }   
            for (int h = 0; h < array.GetLength(0) - 1; h++) 
                answer.Add(array[iInd, jInd += jStep]);

            return answer;
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (var VARIABLE in list)
            {
                Console.Write(VARIABLE + " ");
            }
            {
                
            }
        }
    }
}
