using System;

namespace LAB_1_High_speed_Comp
{
    class Program
    {

        static void Main(string[] args)
        {
            Func<Action<string, int>, int, int> lambda = Func1;
            Action<string, int> actMeth = Act1;

            for (int i = 1; i <= 10; i++)
            {
                lambda(actMeth, i);
                Console.WriteLine();
            }

            Console.Read();
        }

        private static void Act1(string arg1, int arg2)
        {
            Console.Write(arg1);
            Console.Write(arg2);

        }

        private static int Func1(Action<string, int> arg1, int arg2)
        {
            int res = arg2 * arg2;
            arg1("The oroginal number: ", arg2);
            arg1("\t The square of the number: ", res);
            return (res);
        }
    }
}
