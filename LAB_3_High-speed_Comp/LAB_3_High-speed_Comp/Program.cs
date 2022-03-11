using System;
using System.Threading;


namespace LAB_3_High_speed_Comp
{
    class Program
    {
        delegate int MtrxSumFullMethodDelegate(int x, int y);

        static Random random = new Random();

        static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                    Console.Write("{0,5}", array[i, j]);
                Console.WriteLine();
            }
        }

        static int MtrxSumFullMethod(int x, int y)
        {
            int[,] SumMtrx = new int[x, y];

            int[,] Mtrx1 = new int[x, y];
            int[,] Mtrx2 = new int[x, y];

            for (int i = 0; i < Mtrx1.GetLength(0); ++i)
                for (int j = 0; j < Mtrx1.GetLength(1); ++j)
                {
                    Mtrx1[i, j] = random.Next(100) - 50;
                    Mtrx2[i, j] = random.Next(100) - 50;
                }

            for (int i = 0; i < SumMtrx.GetLength(0); ++i)
                for (int j = 0; j < SumMtrx.GetLength(1); ++j)
                    SumMtrx[i, j] = Mtrx1[i, j] + Mtrx2[i, j];

            Print(Mtrx1);
            Console.WriteLine();

            Thread.Sleep(1000);

            Print(Mtrx2);
            Console.WriteLine();

            Thread.Sleep(100);

            Print(SumMtrx);

            return 1;
        }

        static void Main()
        {
            MtrxSumFullMethodDelegate dl = MtrxSumFullMethod;
            IAsyncResult ar = dl.BeginInvoke(5, 5, null, null);
            while (true)
            {
                Console.Write(" . ");
                if (ar.AsyncWaitHandle.WaitOne(50, false))
                {
                    Console.WriteLine("Result can be extracted now");
                    break;
                }
            }
            int result = dl.EndInvoke(ar);

            Console.WriteLine("result: {0}", result);

            Console.Read();
        }
    }
}
