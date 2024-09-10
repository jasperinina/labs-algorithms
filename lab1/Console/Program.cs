using System;
using System.Diagnostics;
 class Program
{
    static void Main(string[] args)
    {
        //      var sw = new Stopwatch();
        //      sw.Start();
        //      for (int i = 0; i < 2000; i++)
        //      {
        //          Console.WriteLine(i);
        //      }
        //      sw.Stop();
        //      Console.WriteLine("Time: " + sw.ElapsedMilliseconds); 
        //sw.Restart();
        //int[,] Matrix_Multiply(int[,] matrix1, int[,] matrix2)
        //{
        //	int[,] final_matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
        //	int result = 0;
        //	for (int i = 0; i < matrix1.GetLength(0); i++)
        //	{
        //		for (int j = 0; j < matrix2.GetLength(1); j++)
        //		{
        //			for (int k = 0; k < matrix2.GetLength(0); k++)
        //			{
        //				result += matrix1[i, k] * matrix2[k,j];
        //			}
        //			final_matrix[i, j] = result;
        //			result = 0;
        //		}
        //	}
        //	return final_matrix;
        //      }
        Random rnd = new Random();
        int[] array = new int[20000];
        for (int i = 0; i < 20000; i++)
        {
            array[i] = rnd.Next();
        }
        var sw = new Stopwatch();
        sw.Start();
        int[] array1 = Quicksort(array, 0, array.Length - 1);
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Reset();
        sw.Start();
        int[] array2 = Bubblesort(array);
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
    public static int[] Quicksort(int[] array, int leftIndex, int rightIndex)
    {
        var l = leftIndex;
        var r = rightIndex;
        var pivot = array[leftIndex];
        while (l <= r)
        {
            while (array[l] < pivot)
            {
                l++;
            }

            while (array[r] > pivot)
            {
                r--;
            }
            if (l <= r)
            {
                int temp = array[l];
                array[l] = array[r];
                array[r] = temp;
                l++;
                r--;
            }
        }
        if (leftIndex < r)
            Quicksort(array, leftIndex, r);
        if (l < rightIndex)
            Quicksort(array, l, rightIndex);
        return array;
    }
    public static int[] Bubblesort(int[] array)
    {
        int temporary;
        for (int j = 0; j <= array.Length - 2; j++)
        {
            for (int i = 0; i <= array.Length - 2; i++)
            {
                if (array[i] > array[i + 1])
                {
                    temporary = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temporary;
                }
            }
        }
        return array;
    }
}
