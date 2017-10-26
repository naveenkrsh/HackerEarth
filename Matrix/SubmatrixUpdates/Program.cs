using System;
using System.Collections.Generic;

namespace SubmatrixUpdates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready");
            var input = Console.ReadLine().Trim().Split(' ');

            int n = Int32.Parse(input[0]);
            int m = Int32.Parse(input[1]);
            int k = Int32.Parse(input[2]);

            long[][] matrix = CreateMatrix(n, m);

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Trim().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = Int32.Parse(data[j]);
                }
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < k; i++)
            {
                var operation = Console.ReadLine().Trim().Split(' ');
                int r = Int32.Parse(operation[0]);
                int c = Int32.Parse(operation[1]);
                int s = Int32.Parse(operation[2]);
                int d = Int32.Parse(operation[3]);

                string key = r.ToString() + " " + c.ToString() + " " + s.ToString();

                if (dic.ContainsKey(key))
                {

                    dic[key] += d;
                }
                else
                {
                    dic[key] = d;
                }
            }

            foreach (var item in dic)
            {
                var operation = item.Key.Split(' ');
                int r = Int32.Parse(operation[0]);
                int c = Int32.Parse(operation[1]);
                int s = Int32.Parse(operation[2]);
                long d = item.Value;

                int endR = n < (r + s - 1) ? n : (r + s - 1);
                int endC = m < (c + s - 1) ? m : (c + s - 1);

                for (int si = r - 1; si < endR; si++)
                {
                    for (int sj = c - 1; sj < endC; sj++)
                    {
                        matrix[si][sj] += d;
                        matrix[si][sj] = matrix[si][sj] % 10000000007;
                    }
                }

            }

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static long[][] CreateMatrix(int row, int column)
        {
            long[][] matrix = new long[row][];

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new long[column];
            }

            return matrix;
        }


    }
}

