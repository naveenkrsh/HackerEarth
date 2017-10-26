using System;
using System.Threading.Tasks;

namespace AkashAndTheAssignment
{
    class Program
    {
        const int SMALL_A = (int)'a';
        const int SMALL_Z = (int)'z';
        const int TOTAL = 26;
        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");
            var input = Console.ReadLine().Trim().Split(' ');
            int N = Int32.Parse(input[0]);
            int Q = Int32.Parse(input[1]);
            var result = new string[Q];

            string str = Console.ReadLine();
            var matix = CalculateChar("0" + str, N);



            for (int i = 0; i < Q; i++)
            {
                var input2 = Console.ReadLine().Split(' ');
                int l = Int32.Parse(input2[0]);
                int r = Int32.Parse(input2[1]);
                int k = Int32.Parse(input2[2]);

                if (r - l + 1 < k || l - r > 0 || l < 0 || r > str.Length)
                {
                    result[i] = "Out of range";
                }
                else
                {
                    result[i] = GetChar(matix, l, r, k).ToString();
                }
            }

            for (int i = 0; i < Q; i++)
                Console.WriteLine(result[i]);

        }

        public static int[][] GetMatrix(int row, int column)
        {
            int[][] matrix = new int[row][];

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[column];
            }

            return matrix;
        }

        public static int[][] CalculateChar(string str, int n)
        {
            int[][] matrix = GetMatrix(TOTAL, n + 1);

            var charArr = str.ToCharArray();
            for (int i = 1; i <= n; i++)
            {
                int letterIndex = charArr[i] - SMALL_A;

                for (int j = 0; j < TOTAL; j++)
                {
                    if (j == letterIndex)
                    {
                        matrix[j][i] = matrix[j][i - 1] + 1;
                    }
                    else
                    {
                        matrix[j][i] = matrix[j][i - 1];
                    }
                }
            }
            return matrix;
        }

        public static char GetChar(int[][] matix, int left, int right, int k)
        {
            int count = 0;
            int i = 0;
            for (i = 0; i < TOTAL; i++)
            {
                count += matix[i][right] - matix[i][left - 1];
                if (count >= k)
                    break;
            }

            return (char)(i + SMALL_A);
        }
    }
}
