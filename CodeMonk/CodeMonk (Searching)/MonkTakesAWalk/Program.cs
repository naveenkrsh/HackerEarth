using System;
using System.Linq;
namespace MonkTakesAWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int t = Int32.Parse(Console.ReadLine().Trim());

            for(int i =0; i< t ; i++)
            {
                string input = Console.ReadLine().Trim().ToLower();
                char[] vowels = new char[]{'a','e','i','o','u'};
                int count=0;
                foreach(char c in input)
                {
                    if(vowels.Contains(c))
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}
