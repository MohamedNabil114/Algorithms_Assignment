using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class HeapSort
{
    public void Sort(int[] array)
    {
        int n = array.Length;

        
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            Heapify(array, i, 0);
        }
    }

    void Heapify(int[] array, int n, int i)
    {
        int largest = i; 
        int left = 2 * i + 1; 
        int right = 2 * i + 2; 

        if (left < n && array[left] > array[largest])
            largest = left;

        if (right < n && array[right] > array[largest])
            largest = right;

        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;

            Heapify(array, n, largest);
        }
    }

    public void PrintArray(int[] array)
    {
        foreach (int item in array)
            Console.Write(item + " ");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", array));

        HeapSort heapSort = new HeapSort();
        heapSort.Sort(array);

        Console.WriteLine("Sorted Array:");
        heapSort.PrintArray(array);
        Console.ReadKey();
    }
}

