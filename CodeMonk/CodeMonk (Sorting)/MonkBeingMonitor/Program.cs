using System;
using System.Linq;

namespace MonkBeingMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int t = Int32.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < t; i++)
            {
                Run();
            }


            //Run();
        }

        private static void Run()
        {
            int n = Int32.Parse(Console.ReadLine().Trim());
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(x => Int32.Parse(x)).ToArray();
            //int[] arr = new int[] { 3, 1, 3, 2, 3, 2 };
            MergeSort(arr, 0, arr.Length - 1);


            int minCount = 1;
            int currentMin = 1;

            int maxCount = 1;
            int currentMax = 1;


            int max = arr[0];
            int min = arr[0];
            int i;
            for (i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] == arr[i])
                    currentMax++;
                else
                {
                    if (maxCount < currentMax)
                    {
                        max = arr[i - 1];
                        maxCount = currentMax;
                    }
                    currentMax = 1;
                }
            }

            if (maxCount < currentMax)
            {
                max = arr[i - 1];
                maxCount = currentMax;
            }

            for (i = 1; i < arr.Length; i++)
            {
                if (arr[i] >= max)
                    break;

                if (arr[i - 1] == arr[i])
                    currentMin++;
                else
                {
                    if (minCount > currentMin)
                    {
                        min = arr[i - 1];
                        minCount = currentMin;
                    }
                    currentMin = 1;
                }
            }

            if (minCount > currentMin)
            {
                min = arr[i - 1];
                minCount = currentMin;
            }

            int result = maxCount - minCount;

            if (result == 0 || min >= max)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(Math.Abs(result));
            }
        }

        static void MergeSort(int[] arr, int low, int right)
        {
            if (low < right)
            {
                int mid = low + (right - low) / 2;

                MergeSort(arr, low, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, low, mid, right);
            }
        }

        static void Merge(int[] arr, int low, int mid, int high)
        {
            int[] A = new int[mid - low + 1];
            int[] B = new int[high - mid];

            int i = 0;
            int j = low;
            for (j = low; j <= mid; j++)
            {
                A[i] = arr[j];
                i++;
            }

            i = 0;
            for (j = mid + 1; j <= high; j++)
            {
                B[i] = arr[j];
                i++;
            }

            i = 0;
            j = low;
            int r = 0;
            while (i < A.Length && r < B.Length)
            {
                if (A[i] <= B[r])
                {
                    arr[j] = A[i];
                    i++;
                }
                else
                {
                    arr[j] = B[r];
                    r++;
                }
                j++;
            }

            while (i < A.Length)
            {
                arr[j++] = A[i++];
            }

            while (r < B.Length)
            {
                arr[j++] = B[r++];
            }
        }
    }
}