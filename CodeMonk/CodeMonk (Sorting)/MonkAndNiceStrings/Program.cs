using System;

namespace MonkAndNiceStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            int n = Int32.Parse(Console.ReadLine().Trim());
            string[] arr = new string[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Console.ReadLine().Trim();
            }

            //PrintNiceness(new string[] { "a", "c", "d", "b" });
            PrintNiceness(arr);
        }

        static void PrintNiceness(string[] arr)
        {
            Console.WriteLine(0);

            for (int i = 1; i < arr.Length; i++)
            {
                Console.WriteLine(GetNiceness(arr, i));
            }
        }

        static int GetNiceness(string[] arr, int n)
        {
            int result = 0;
            string str = arr[n];
            for (int i = 0; i < n; i++)
            {
                if (str.CompareTo(arr[i]) == 1)
                    result++;
            }

            return result;
        }


    }
}
