using System;

namespace MonkAndRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Int32.Parse(Console.ReadLine().Trim());



            for (int tc = 0; tc < t; tc++)
            {
                var input = Console.ReadLine().Trim().Split(' ');
                int n = Int32.Parse(input[0]);
                int k = Int32.Parse(input[1]);
                var arr = Console.ReadLine().Trim().Split(' ');

                if (k > n)
                    k = k % n;

                if (k != n)
                {

                    RotateArray(arr, 0, n - 1 - k);
                    RotateArray(arr, n - k, n - 1);
                    RotateArray(arr, 0, n - 1);
                }

                //result[tc] = new string[n];
                // for (int i = 0; i < n; i++)
                // {
                //     Console.Write(arr[i]);
                //     Console.Write(" ");
                // }
                Console.WriteLine(string.Join(" ",arr));

            }
        }

        static void RotateArray(string[] arr, int start, int end)
        {
            while (start < end)
            {
                string temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

    }
}
