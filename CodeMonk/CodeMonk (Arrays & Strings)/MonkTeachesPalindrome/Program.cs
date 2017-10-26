using System;

namespace MonkTeachesPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Read input from stdin and provide input before running */
            var line1 = System.Console.ReadLine().Trim();
            var T = Int32.Parse(line1);
            var result = new string[T];
            for (var i = 0; i < T; i++)
            {

                var line2 = Console.ReadLine().Trim().ToCharArray();
                int m = line2.Length - 1;
                int j = 0;
                bool pali = true;
                while (j < m)
                {
                    if (line2[j] != line2[m])
                    {
                        pali = false;
                        break;
                    }

                    j++;
                    m--;
                }

                if (pali)
                {
                    if (line2.Length % 2 == 0)
                    {
                        result[i] = "YES EVEN";
                    }
                    else
                    {
                        result[i] = "YES ODD";
                    }
                }
                else
                {
                    result[i] = "NO";

                }
            }
            for (int i = 0; i < T; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
