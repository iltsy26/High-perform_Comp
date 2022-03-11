using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2_High_speed_Comp
{
    class Program
    {
        static Random random = new Random();

        static int[,] InitializeMtrx(int x, int y)
        {
            int[,] Mtrx = new int[x, y];
            for (int i = 0; i < Mtrx.GetLength(0); ++i)
                for (int j = 0; j < Mtrx.GetLength(1); ++j)
                {
                    Mtrx[i, j] = random.Next(100) - 50;
                }
            return Mtrx;
        }

        static int[,] SumOfMtrx(int[,] Mtrx1, int[,] Mtrx2, int x, int y)
        {
            int[,] SumMtrx = new int[x, y];

            for (int i = 0; i < SumMtrx.GetLength(0); ++i)
                for (int j = 0; j < SumMtrx.GetLength(1); ++j)
                    SumMtrx[i, j] = Mtrx1[i, j] + Mtrx2[i, j];

            return SumMtrx;
        }

        static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                    Console.Write("{0,5}", array[i, j]);
                Console.WriteLine();
            }
        }

        static void Main()
        {

            Func<Task<int[,]>> MtrxSum = async () =>
            {
                Console.WriteLine("Sum Method started");

                int x = 4, y = 4;
                int[,] Mtrx1 = InitializeMtrx(x, y);
                int[,] Mtrx2 = InitializeMtrx(x, y);
                int[,] SumMtrx = SumOfMtrx(Mtrx1, Mtrx2, x, y);

                Print(Mtrx1);
                Console.WriteLine();

                Task task = Task.Delay(100);
                while (!task.IsCompleted)
                {
                    Console.Write('+');
                }
                Console.WriteLine();
                Console.WriteLine();
                Print(Mtrx2);
                await task;
                Console.WriteLine();
                Print(SumMtrx);
                Console.WriteLine("Sum Method finished");

                return SumMtrx;
            };

            MtrxSum();

            Console.Read();
        }
    }
}
