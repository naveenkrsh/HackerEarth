using System;
using System.Linq;
namespace MonkAndSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            int n = Int32.Parse(Console.ReadLine().Trim());
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(x => Int32.Parse(x)).ToArray();
            Array.Sort(arr);

            //Print(arr);
            //MergeSort(arr, 0, n - 1);

            int q = Int32.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < q; i++)
            {
                int[] query = Console.ReadLine().Trim().Split(' ').Select(x => Int32.Parse(x)).ToArray();
                int operation = query[0];
                int value = query[1];




                if (operation == 0)
                {
                    if (arr[0] >= value)
                    {
                        Console.WriteLine(n);
                    }
                    else if (arr[n - 1] < value)
                        Console.WriteLine(0);
                    else if(arr[n-1]== value)
                    {
                        Console.WriteLine(n-MoveBack(arr,n-1));
                    }
                    else
                    {
                        var result = GetNearestNumberIndex(arr, value, 0, n - 1);
                        Console.WriteLine(n - MoveBack(arr, result.Item1));
                    }
                }
                else
                {
                    if (arr[n - 1] < value)
                        Console.WriteLine(0);
                    else if(arr[0]== value)
                    {
                        Console.WriteLine(n-MoveNext(arr,0)-1);
                    }
                    else if (arr[0] > value)
                    {
                        Console.WriteLine(n);
                    }
                    else
                    {
                        var result = GetNearestNumberIndex(arr, value, 0, n - 1);

                        if (result.Item2)
                        {
                            Console.WriteLine(n - MoveNext(arr, result.Item1) - 1);
                        }
                        else
                            Console.WriteLine(n - MoveBack(arr, result.Item1));
                    }

                }

            }
        }

        static int MoveBack(int[] arr, int index)
        {
            while (index > 0 && arr[index - 1] == arr[index])
            {
                index--;
            }
            return index;
        }

        static int MoveNext(int[] arr, int index)
        {
            while (index < arr.Length - 1 && arr[index + 1] == arr[index])
            {
                index++;
            }
            return index;
        }
        static Tuple<int, bool> GetNearestNumberIndex(int[] arr, int value, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == value)
                {

                    return new Tuple<int, bool>(mid, true);
                }
                else if (arr[mid] < value)
                {
                    if (arr[mid + 1] >= value)
                    {
                        return new Tuple<int, bool>(mid + 1, arr[mid + 1] == value);
                    }
                    return GetNearestNumberIndex(arr, value, mid + 1, high);
                }
                else
                {
                    if (mid != 0 && arr[mid - 1] < value)
                        return new Tuple<int, bool>(mid, false);

                    return GetNearestNumberIndex(arr, value, low, mid - 1);
                }
            }

            return new Tuple<int, bool>(0, false);
        }

        static void Print(int[] arr)
        {
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("{0}:{1}", i, arr[i]);
        }
    }
}
