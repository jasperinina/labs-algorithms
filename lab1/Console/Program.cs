using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        var sw = new Stopwatch();
        //int[,] matrix = MatrixGenerate(900, 1000);
        //int[,] matrix2 = MatrixGenerate(900, 1000);
        //int[] array = ArrayGenerate(200);
        //var array1 = (int[])array.Clone();
        sw.Start();
        //int constanta = Const_function(array1);
        //int sum = Sum_numbers(array1);
        //int proizvedenie = Multiply_numbers(array1);
        //Bubblesort(array1);
        //Quicksort(array1, 0, array1.Length - 1);
        //Timsort(array1);
        //int[,] final_matrix = Matrix_Multiply(matrix, matrix2);
        sw.Stop();
        Console.WriteLine("time: " + sw.ElapsedTicks);
    }
    static void Bubblesort(int[] array)
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
    }
    static void Quicksort(int[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }
        if (leftIndex < j)
            Quicksort(array, leftIndex, j);
        if (i < rightIndex)
            Quicksort(array, i, rightIndex);
    }
    static int min_merge = 32;
    static void InsertionSort(int[] array, int left, int right)
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
    static void Merge(int[] array, int l, int m, int r)
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
    static void Timsort(int[] array)
    {
        for (int i = 0; i < array.Length; i += min_merge)
        {
            InsertionSort(array, i, Math.Min(i + min_merge - 1, array.Length - 1));
        }
        for (int size = min_merge; size < array.Length; size *= 2)
        {
            for (int left = 0; left < array.Length; left += 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min(left + 2 * size, array.Length - 1);
                if (mid < right)
                {
                    Merge(array, left, mid, right);
                }
            }
        }
    }
    static int[,] Matrix_Multiply(int[,] matrix1, int[,] matrix2)
    {
        int[,] final_matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
        int result = 0;
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                for (int k = 0; k < matrix2.GetLength(0); k++)
                {
                    result += matrix1[i, k] * matrix2[k, j];
                }
                final_matrix[i, j] = result;
                result = 0;
            }
        }
        return final_matrix;
    }
    static void MatrixFill(int[,] matrix, int max_random_value)
    {
        Random rnd = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rnd.Next(max_random_value);
            }
        }
    }
    static int[,] MatrixGenerate(int matrix_dim, int max_random_value)
    {
        int[,] matrix = new int[matrix_dim, matrix_dim];
        MatrixFill(matrix, max_random_value);
        return matrix;
    }
    static int[] ArrayGenerate(int array_len)
    {
        Random rnd = new Random();
        int[] array = new int[array_len];
        for (int i = 0; i < array_len; i++)
        {
            array[i] = rnd.Next(1, 1);
        }
        return array;
    }
    static int Multiply_numbers(int[] array)
    {
        int result = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            result *= array[i];
        }
        return result;
    }
    static int Sum_numbers(int[] array)
    {
        int result = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            result += array[i];
        }
        return result;
    }
    static int Const_function(int[] array)
    {;
        return array[0];
    }
    static float[] ArrayAverage(params float[][] arrays)
    {
        return Enumerable.Range(0, arrays[0].Length)
                   .Select(i => arrays.Select(a => a.Skip(i).First()).Average())
                   .ToArray();
    }
}
