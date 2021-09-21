using System;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var matrixA = GetMatrixFromConsole("A");
            var LineMin = new float[matrixA.GetUpperBound(0) + 1];
            var LineMax = new float[matrixA.GetUpperBound(0) + 1];
            
            Solution1(matrixA, LineMin, LineMax);

            PrintMatrix(matrixA);
            PrintVector(LineMin, "Min");
            PrintVector(LineMax, "Max");
            
            Console.WriteLine(composition(LineMin, LineMax));
            
            Console.Write(Solution2(matrixA));
        }

        static double composition(float[] lineMin, float[] lineMax)
        {
            float comp = 1;
            for (var i = 0; i < (lineMin.GetUpperBound(0) + 1); i++)
            {
                comp *= (lineMax[i] * lineMin[i]);
            }

            return comp;
        }

        static void Solution1(float[,] a, float[] lineMin, float[] lineMax)
        {
            var currLine = new float[a.GetUpperBound(0) + 1];
            float sumCurrLine = 0, Max = -9999, Min = 9999;
            for (var i = 0; i < (a.GetUpperBound(0)+1); i++)
            {
                for (var j = 0; j < (a.GetUpperBound(1)+1); j++)
                {
                    currLine[j] = a[i, j];
                    sumCurrLine += a[i, j];
                }

                if (sumCurrLine > Max)
                {
                    Max = sumCurrLine;
                    currLine.CopyTo(lineMax, 0);
                }
                if (sumCurrLine < Min)
                {
                    Min = sumCurrLine;
                    currLine.CopyTo(lineMin, 0);
                }

                sumCurrLine = 0;
            }
        }
        
        static double Solution2(float[,] a)
        {
            var currLine = new float[a.GetUpperBound(0) + 1];
            float Max = -9999;
            float Min = 9999;
            float compMax = 1;
            float compMin = 1;
            float compCurrLine = 1;
            float sumCurrLine = 0;
            for (var i = 0; i < (a.GetUpperBound(0)+1); i++)
            {
                for (var j = 0; j < (a.GetUpperBound(1)+1); j++)
                {
                    sumCurrLine += a[i, j];
                    compCurrLine *= a[i, j];
                }

                if (sumCurrLine > Max)
                {
                    Max = sumCurrLine;
                    compMax = compCurrLine;
                }
                if (sumCurrLine < Min)
                {
                    Min = sumCurrLine;
                    compMin = compCurrLine;
                }

                sumCurrLine = 0;
                compCurrLine = 1;
            }

            return (compMax * compMin);
        }

        // Метод для ввода матрицы с консоли 
        static float[,] GetMatrixFromConsole(string name)
        {
            Console.WriteLine("Количество строк матрицы {0}:   ", name);
            var n = int.Parse(Console.ReadLine());

            var matrix = new float[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("{0}[{1}{2}]: ", name, i , j);
                    matrix[i, j] = float.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }
        
        // метод для печати матрицы в консоль
        static void PrintMatrix(float[,] matrix)
        {
            for (var i = 0; i < (matrix.GetUpperBound(0)+1); i++)
            {
                for (var j = 0; j < (matrix.GetUpperBound(1)+1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        // метод для печати вектора в консоль
        static void PrintVector(float[] vector, string name)
        {
            Console.Write("{0} = ", name);
            for (var i = 0; i < (vector.GetUpperBound(0)+1); i++)
            {
                Console.Write("{0} ", vector[i].ToString());
            }
            Console.WriteLine();
        }
    }
}