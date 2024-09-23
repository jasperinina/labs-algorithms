using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class algorithm
    {
        public static int Const_function(int[] array)
        {
            return array[array.Length - 1];
        }
        public static int Sum_numbers(int[] array)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }
        public static int Multiply_numbers(int[] array)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                result *= array[i];
            }
            return result;
        }
        public static void Bubblesort(int[] array)
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
        public static void Quicksort(int[] array, int leftIndex, int rightIndex)
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
        public static int min_merge = 32;
        public static void InsertionSort(int[] array, int left, int right)
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
        public static void Merge(int[] array, int l, int m, int r)
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
        public static void Timsort(int[] array)
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
        public static int[,] Matrix_Multiply(int[,] matrix1, int[,] matrix2)
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
        public static void MatrixFill(int[,] matrix, int max_random_value)
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
        public static int[,] MatrixGenerate(int matrix_dim, int max_random_value)
        {
            int[,] matrix = new int[matrix_dim, matrix_dim];
            MatrixFill(matrix, max_random_value);
            return matrix;
        }
        public static int[] ArrayGenerate(int array_len)
        {
            Random rnd = new Random();
            int[] array = new int[array_len];
            for (int i = 0; i < array_len; i++)
            {
                array[i] = rnd.Next(1, 1);
            }
            return array;
        }
        public static float[] ArrayAverage(params float[][] arrays)
        {
            return Enumerable.Range(0, arrays[0].Length)
                       .Select(i => arrays.Select(a => a.Skip(i).First()).Average())
                       .ToArray();
        }
        public static long SimplePow(int x, int n)
        {
            long result = 1;
            int count = 0;
            while (count < n)
            {
                result *= x;
                count++;
            }
            return result;
        }
        public static long RecPow (int x, int n)
        {
            long result = 1;
            if (n != 0)
            {
                result = RecPow(x, n / 2);
                if (n % 2 == 1)
                {
                    result = result * result * x;
                }
                else
                {
                    result *= result;
                }
            }
            return result;
        }
        public static long QuickPowFaster (int x, int n)
        {
            long result;
            if (n % 2 == 1) { result = x; }
            else { result = 1; }
            while (n != 0)
            {
                n /= 2;
                x *= x;
                if (n % 2 == 1) { result *= x; }
            }
            return result;
        }
        public static long QuickPowClassic (int x, int n)
        {
            long result = 1;
            while (n != 0)
            {
                if (n % 2 == 0)
                {
                    x *= x;
                    n /= 2;
                }
                else
                {
                    result *= x;
                    n--;
                }
            }
            return result;
        }
    }
}
