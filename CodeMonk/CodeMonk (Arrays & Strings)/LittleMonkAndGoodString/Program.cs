using System;
using System.Linq;
namespace LittleMonkAndGoodString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().Trim();

            int max = 0;
            int currentMax = 0;
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            foreach (char c in str)
            {
                if (vowels.Contains(c))
                {
                    currentMax++;
                }
                else
                {
                    if (currentMax > max)
                    {
                        max = currentMax;
                    }
                    currentMax = 0;
                }

            }

            if (currentMax > max)
            {
                max = currentMax;
            }

            Console.Write(max);
        }
    }
}
