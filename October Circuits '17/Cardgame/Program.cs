using System;
using System.Linq;
namespace Cardgame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            long m =Int64.Parse(Console.ReadLine().Trim());
            long[] a = Console.ReadLine().Trim().Split(' ').Select(x=> Int64.Parse(x)).ToArray();

            long n =Int64.Parse(Console.ReadLine().Trim());
            long[] b = Console.ReadLine().Trim().Split(' ').Select(x=> Int64.Parse(x)).ToArray();

            long maxB = b.Max();
            
            var less =  a.Where(x=> x <= maxB);

            var total = (long)less.Count() * (maxB + 1);

            var aTotal = less.Sum(x=> x%(10000000007));

            Console.WriteLine(total-aTotal);
        }
    }
}
