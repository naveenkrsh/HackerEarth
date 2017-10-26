using System;

namespace MonkAndInversions
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Int32.Parse(Console.ReadLine().Trim());
            var result = new int[t];
            for (int tc = 0; tc < t; tc++)
            {
                var n = Int32.Parse(Console.ReadLine().Trim());

                int[,] arr = new int[n, n];

                for (var i = 0; i < n; i++)
                {
                    var line = Console.ReadLine().Trim().Split(' ');

                    for (var j = 0; j < n; j++)
                    {
                        arr[i, j] = Int32.Parse(line[j]);
                    }
                }

                result[tc] = Count(arr, n);
            }

            for (int i = 0; i < t; i++)
                System.Console.WriteLine(result[i]);
        }

        static int Count(int[,] arr, int n)
        {
            int s = 0;
            int result = 0;

            for (s = 0; s < n; s++)
            {
                for (int m = 0; m < n; m++)
                {
                    int v = arr[s, m];
                    result += CountInSubMatrix(arr,v,s,m,n);
                }
                // for (int i = s; i < n - 1; i++)
                // {
                //     if (arr[s, i] > arr[s, i + 1])
                //         result++;
                // }

                // for (int j = s; j < n - 1; j++)
                // {
                //     if (arr[j, s] > arr[j + 1, s])
                //         result++;
                // }
            }

            return result;
        }

        static int CountInSubMatrix(int[,] arr, int value, int i, int j, int n)
        {
            int result = 0;
            for (int r = i; r < n; r++)
            {
                for (int c = j; c < n; c++)
                {
                    if (arr[r, c] < value)
                        result++;
                }
            }

            return result;
        }
    }
}
