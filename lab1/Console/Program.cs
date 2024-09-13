using System;
using System.Diagnostics;
using Algorithms;
class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        var sw = new Stopwatch();
        int[,] matrix = algorithm.MatrixGenerate(900, 1000);
        int[,] matrix2 = algorithm.MatrixGenerate(900, 1000);
        //int[] array = ArrayGenerate(200);
        //var array1 = (int[])array.Clone();
        sw.Start();
        //int constanta = Const_function(array1);
        //int sum = Sum_numbers(array1);
        //int proizvedenie = Multiply_numbers(array1);
        //Bubblesort(array1);
        //Quicksort(array1, 0, array1.Length - 1);
        //Timsort(array1);
        int[,] final_matrix = algorithm.Matrix_Multiply(matrix, matrix2);
        sw.Stop();
        Console.WriteLine("time: " + sw.ElapsedMilliseconds);
    }
}
