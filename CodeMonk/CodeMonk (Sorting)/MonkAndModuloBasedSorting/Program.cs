using System;
using System.Linq;
namespace MonkAndModuloBasedSorting
{
    class Program
    {
        static int modk =0;
        static void Main(string[] args)
        {
            Console.WriteLine("Ready");
            var input = Console.ReadLine().Trim().Split(' ');
            int N = Int32.Parse(input[0]);
            modk = Int32.Parse(input[1]);
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(x=>Int32.Parse(x)).ToArray();
            QuickSort(arr,0,arr.Length-1);
            Print(arr);
        }

        static void Merge(int[] arr, int low, int mid, int high)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            int[] A1 = new int[n1];
            int[] A2 = new int[n2];
            int k = 0;
            int i = 0;
            int j = 0;
            for (i = low; i <= mid; i++)
            {
                A1[k++] = arr[i];
            }

            k = 0;
            for (i = mid + 1; i <= high; i++)
            {
                A2[k++] = arr[i];
            }

            k = low;
            i = 0;
            j = 0;
            while (i < n1 && j < n2)
            {
                if (A1[i]%modk <= A2[j]%modk)
                {
                    arr[k] = A1[i];
                    i++;
                }
                else
                {
                    arr[k] = A2[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = A1[i];
                k++;
                i++;
            }
            while (j < n2)
            {
                arr[k] = A2[j];
                k++;
                j++;
            }

        }

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;

                QuickSort(arr, low, mid);
                QuickSort(arr, mid + 1, high);
                Merge(arr, low, mid, high);
            }
        }

        static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
