using System;

namespace MonkAndCircularDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            int n = Int32.Parse(Console.ReadLine());
            var arr = GetDistanceArray(n);

            Array.Sort(arr);
            //Print(arr);
            int q = Int32.Parse(Console.ReadLine().Trim());


            ProcessQuery(arr, q);
            // double a = -1.23;
            // var b = Math.Abs(a);
            // Console.WriteLine(b);
            // Console.WriteLine(Math.Ceiling(b));
        }

        static void ProcessQuery(double[] arr, int q)
        {

            for (int i = 0; i < q; i++)
            {
                double r = double.Parse(Console.ReadLine().Trim());
                ProcessRadius(arr, r);
            }

        }

        private static void ProcessRadius(double[] arr, double value)
        {
            int n = arr.Length;
            if (arr[0] > value)
                Console.WriteLine(0);
            else if (arr[n - 1] <= value)
                Console.WriteLine(n);
            // else if (arr[n - 1] == value)
            //     Console.WriteLine(n - MoveNext(arr, n - 1));
            else
            {
                var result = GetNearestNumberIndex(arr, value, 0, n - 1);
                Console.WriteLine(MoveNext(arr, result)+1);
            }
        }

        static int MoveBack(double[] arr, int index)
        {
            while (index > 0 && arr[index - 1] == arr[index])
            {
                index--;
            }
            return index;
        }

        static int MoveNext(double[] arr, int index)
        {
            while (index < arr.Length - 1 && arr[index + 1] == arr[index])
            {
                index++;
            }
            return index;
        }
        static int GetNearestNumberIndex(double[] arr, double value, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;
               
                if (arr[mid] == value)
                {
                    return mid;
                }
                else if (arr[mid] < value)
                {
                    if (arr[mid + 1] > value)
                    {
                        return mid;
                    }
                    return GetNearestNumberIndex(arr, value, mid + 1, high);
                }
                else
                {
                    
                    if (mid != 0 && arr[mid - 1] <= value)
                        return mid - 1;

                    return GetNearestNumberIndex(arr, value, low, mid - 1);
                }
            }
            return 0;
        }

        private static double[] GetDistanceArray(int n)
        {

            double[] arr = new double[n];

            for (int i = 0; i < n; i++)
            {
                var inputxy = Console.ReadLine().Trim().Split(' ');

                long x = Int64.Parse(inputxy[0]);
                long y = Int64.Parse(inputxy[1]);

                var distance = GetDistance(x, y);
                arr[i] = distance;
            }

            return arr;
        }

        private static double GetDistance(long x, long y)
        {
            double c2 = (x * x) + (y * y);
            double d = Math.Ceiling(Math.Abs(Math.Sqrt(c2)));

            return d;
        }

        static void Print(double[] arr)
        {
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("{0}:{1}", i, arr[i]);
        }
    }
}
