using System;

namespace MonkAndSuffixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var input = Console.ReadLine().Trim().Split(' ');

            string str = input[0];
            int k = Int32.Parse(input[1]);

            string[] strArr = new string[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                strArr[i] = str.Substring(i, str.Length - i);
            }

            // for (int i = 0; i < strArr.Length; i++)
            // {
            //     Console.WriteLine(strArr[i]);
            // }

            //Console.WriteLine("aaa".CompareTo("bbbb"));
            int min = 0;
            for (int i = 0; i < k; i++)
            {
                min = i;
                
                for (int j = i; j < strArr.Length ; j++)
                {
                    
                    if (strArr[i].CompareTo(strArr[j]) == 1)
                    {
                        min = j;
                    }
                }

                var temp = strArr[i];
                strArr[i] = strArr[min];
                strArr[min] = temp;
            }

            Console.WriteLine(strArr[k - 1]);
        }
    }
}
