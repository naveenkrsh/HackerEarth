using System;

namespace RoyAndSymmetricLogos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Start");
            int t = Int32.Parse(Console.ReadLine().Trim());
            bool[] result = new bool[t];
            for (int i = 0; i < t; i++)
            {

                int n = Int32.Parse(Console.ReadLine().Trim());
                int[][] matrix = CreateMatrix(n, n);
                 
                for (int index = 0; index < n; index++)
                {
                    var arr = Console.ReadLine().Trim().ToCharArray();
                    
                    for (int j = 0; j < n; j++)
                    {
                       
                        SetValue(matrix, index, j, Int32.Parse(arr[j].ToString()));
                    }
                }
                result[i] = IsSymetric(matrix);
            }


            for (int i = 0; i < t; i++)
                Console.WriteLine(result[i] ? "YES" : "NO");

            //Console.Write("End");
        }


        public static bool IsSymetric(int[][] matrix)
        {
            bool result = true;
            //x-axis 
            for (int i = 0; i < matrix.Length; i++)
            {
                int upper = i;
                int lower = matrix.Length - 1 - upper;
                if (upper < lower)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if (matrix[upper][j] != matrix[lower][j])
                        {
                            result = false;
                            break;
                        }
                    }
                }
                else
                    break;

                
            }

            //y-axis 

            for (int i = 0; i < matrix.Length;i++)
            {
                int left = i;
                int right = matrix.Length - 1 - left;
                if (left < right)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if (matrix[j][left] != matrix[j][right])
                        {
                            result = false;
                            break;
                        }
                    }
                }
                else
                    break;
            }


            return result;
        }
        public static int[][] CreateMatrix(int row, int column)
        {
            int[][] matrix = new int[row][];

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[column];
            }
            return matrix;
        }

        public static void SetValue(int[][] matrix, int x, int y, int value)
        {
            matrix[x][y] = value;
        }
    }


}
