using System;
using System.Collections.Generic;

namespace MonkAndPhilosopherStone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Stack<ulong> monkbag = new Stack<ulong>();

            int n = Int32.Parse(Console.ReadLine().Trim());

            var coins = Console.ReadLine().Trim().Split(' ');

            var inputqx = Console.ReadLine().Trim().Split(' ');

            int q = Int32.Parse(inputqx[0]);
            ulong x = UInt32.Parse(inputqx[1]);

            ulong monkbagTotal = 0;
            int harryIndex = 0;
            ulong coinValue = 0;
            int result = -1;
         
            for (int i = 0; i < q; i++)
            {
                var message = Console.ReadLine().Trim();

                if (message == "Harry")
                {
                    coinValue = UInt32.Parse(coins[harryIndex]);
                    monkbagTotal =monkbagTotal+ coinValue;
                    monkbag.Push(coinValue);
                    harryIndex++;
                }
                else if(message == "Remove")
                {
                    coinValue = monkbag.Pop();
                    monkbagTotal = monkbagTotal - coinValue;
                }

                if(monkbagTotal == x)
                {
                    result = monkbag.Count;
                    break;
                }
            }

            Console.WriteLine(result);
        }

    }
}
