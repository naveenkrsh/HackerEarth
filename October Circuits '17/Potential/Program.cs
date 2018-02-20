using System;
using System.Linq;
namespace Potential
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Ready");
            var nq = Console.ReadLine().Trim().Split(' ').Select(i => Int64.Parse(i)).ToArray();
            long N = nq[0];
            long Q = nq[1];

            long[] X = Console.ReadLine().Trim().Split(' ').Select(i => Int64.Parse(i)).ToArray();//new long[] { 1, 3, 0 };
            long[] P = Console.ReadLine().Trim().Split(' ').Select(i => Int64.Parse(i)).ToArray();//new long[] { 2, -1, 10 };

            for (long q = 0; q < Q; q++)
            {
                var input = Console.ReadLine().Trim().Split(' ').Select(i => Int64.Parse(i)).ToArray();

                if (input[0] == 1)
                {
                    Operation12(X, input[1], input[2]);
                }
                else if (input[0] == 2)
                {
                    Operation12(P, input[1], input[2]);
                }
                else if (input[0] == 3)
                {
                    CaculateAndPrint(X, P, input[1], input[2]);
                }
            }
        }

        static void Operation12(long[] arr, long pos, long value)
        {
            arr[pos - 1] = value;
        }

        static void CaculateAndPrint(long[] xArr, long[] pArr, long a, long b)
        {
            long currentMax = 0;
            
            for (long i = a; i <= b; i++)
            {
                long value = xArr[i - 1] + Math.Min(pArr[i - 1], i - a);// % 1000000007;
                currentMax = Math.Max(currentMax, value);
            }

            Console.WriteLine(currentMax);
        }
    }
}
