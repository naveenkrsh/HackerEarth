using System;
using System.Collections.Generic;

namespace TheFootballFest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int t = Int32.Parse(Console.ReadLine().Trim());
            int[] result = new int[t];
            for (int i = 0; i < t; i++)
            {
                var input = Console.ReadLine().Trim().Split(' ');

                int n = Int32.Parse(input[0]);
                int id = Int32.Parse(input[1]);
                Stack<int> stack = new Stack<int>();
                stack.Push(id);
                int res = 0;
                int last = 0;
                
                for(int j =0; j < n; j++)
                {
                    var pass=  Console.ReadLine().Trim().Split(' ');
                    if(pass[0]=="P" )
                    {
                        res = Int32.Parse(pass[1]);
                        stack.Push(res);
                        last =0;
                    }
                    else if(pass[0]=="B" && last==1)
                    {
                         stack.Push(res);
                         last =0;
                    }
                    else
                    {
                        last++;
                        res = stack.Pop();
                    }
                }

                result[i]= stack.Peek();
            }


            for(int i =0; i< t ; i++)
            {
                Console.WriteLine("Player {0}",result[i]);
            }
        }
    }
}
