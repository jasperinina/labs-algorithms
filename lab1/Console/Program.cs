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
        int[] array = new int[100000];
        for (int i = 0; i < 100000; i++)
        {
            array[i] = rnd.Next();
        }
        var array1 = (int[])array.Clone();
        var array2 = (int[])array.Clone();
        var array3 = (int[])array.Clone();
        var sw = new Stopwatch();
        sw.Start();
        int[] QSed_array = Quicksort(array1, 0, array1.Length - 1);
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Reset();
        sw.Start();
        int[] BSed_array = Bubblesort(array2);
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Reset();
        sw.Start();
        Timsort(array3, 100000);
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
        int temp;
        for (int j = 0; j < array.Length - 1; j++)
        {
            for (int i = 0; i < array.Length - j - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
        }
        return array;
    }
    static int min_merge = 32;
    static void insertionSort(int[] array, int left, int right)
    {
        for (int i = left + 1; i < right; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= left && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
	static void merge(int[] array, int l, int m, int r)
	{
		int len1 = m - l + 1;
		int len2 = r - m;
        int[] left = new int[len1];
		int[] right = new int[len2];
		for (int a = 0; a < len1; a++)
		{
            left[a] = array[l + 1];
		}
		for (int c = 0; c < len2; c++)
		{
            right[c] = array[m + 1 + c];
		}
		int i = 0, j = 0, k = l;
		while (i < len1 && j < len2)
		{
			if (left[i] <= right[j])
			{
				array[k] = left[i];
				i++;
			} 
			else
			{
				array[k] = right[j];
				j++;
			}
			k++;
		}
		while (i < len1)
		{
            array[k] = left[i];
			i++;
			k++;
		}
		while (j < len2)
		{
            array[k] = right[j];
			j++;
			k++;
		}
	}
	static void Timsort(int[] array, int n)
	{
        for (int i = 0; i < n; i+= min_merge)
        {
            insertionSort(array, i, Math.Min(i + min_merge - 1, n-1));
        }
        for (int size = min_merge; size < n; size *= 2)
        {
            for (int left = 0; left < n; left+= 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min(left + 2 * size, n - 1);
                if (mid < right)
                {
                    merge(array, left, mid, right);
                }
            }
        }
	}
}
