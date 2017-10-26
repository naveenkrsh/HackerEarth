using System;

namespace AddAlternateElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var arr = Console.ReadLine().Trim().Split(' ');

            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < arr.Length; i = i + 2)
            {
                sum1 += Int32.Parse(arr[i]);
                if (i <= 7)
                    sum2 += Int32.Parse(arr[i + 1]);
            }

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
        }
    }
}
