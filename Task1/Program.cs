using System;
using System.IO;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allText = File.ReadAllText("INPUT.txt").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] nValues = allText[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int xn;
            int yn;
            bool okX = int.TryParse(nValues[0], out xn);
            bool okY = int.TryParse(nValues[1], out yn);

            if (!okX || !okY)
                Environment.Exit(0);
            int k = int.Parse(allText[1]);

            int[][] x = new int[k][];
            int[][] y = new int[k][];
            int[] answer = new int[k];

            int count = 0;
            int answerIndex = 0;

            for (int i = 0; i < k; ++i)
            {
                x[i] = new int[3];
                y[i] = new int[3];
                string[] values = allText[2 + i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int index = 0;
                int xIndex = 0;
                int yIndex = 0;
                foreach (string elem in values)
                {
                    if (index % 2 == 0)
                    {
                        bool ok = int.TryParse(elem, out x[i][xIndex]);
                        if (!ok) 
                            Environment.Exit(0);
                        xIndex++;
                    }
                    else
                    {
                        bool ok = int.TryParse(elem, out y[i][yIndex]);
                        if (!ok)
                            Environment.Exit(0);
                        yIndex++;
                    }
                    index++;
                }

                int a = (x[i][0] - xn) * (y[i][1] - y[i][0]) - (x[i][1] - x[i][0]) * (y[i][0] - yn);
                int b = (x[i][1] - xn) * (y[i][2] - y[i][1]) - (x[i][2] - x[i][1]) * (y[i][1] - yn);
                int c = (x[i][2] - xn) * (y[i][0] - y[i][2]) - (x[i][0] - x[i][2]) * (y[i][2] - yn);

                if ((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c < 0))
                {
                    count++;
                    answer[answerIndex] = i + 1;
                    answerIndex += 1;

                }

            }
            
            Array.Resize(ref answer, count);

            string output = $"{count}\n";
            foreach (int elem in answer)
            {
                Console.WriteLine(elem);
                output += $"{elem} ";
            }
            File.WriteAllText("OUTPUT.txt", output);


           
        }
        
    }
}
