using System.Diagnostics;
using Algorithm.Mathematical_Operations.Basic_Operation;
using Algorithm.Mathematical_Operations.Polynomial_Operation;
using Algorithm.Sorting_Algorithms;

namespace Algorithm.Test_Algorithms;

public class TimeTrackerOther
    {
        // Метод для измерения времени выполнения базовой операции (BasicOperation)
        public double MeasureExecutionTimeBasic(BasicOperation operation, int iterations, int[] data)
        {
            Stopwatch stopwatch = new Stopwatch();
            double totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                stopwatch.Restart();
                operation.PerformOperation(data); // Запуск базовой операции
                stopwatch.Stop();
                totalTime += stopwatch.Elapsed.TotalMilliseconds;
            }

            return (totalTime / iterations) / 1000.0; // Возвращаем среднее время выполнения
        }

        // Метод для измерения времени выполнения полиномиальной операции (PolynomialOperations)
        public double MeasureExecutionTimePolynomial(PolynomialOperations operation, int iterations, double x, double[] coefficients)
        {
            Stopwatch stopwatch = new Stopwatch();
            double totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                stopwatch.Restart();
                operation.Evaluate(x, coefficients); // Запуск полиномиальной операции
                stopwatch.Stop();
                totalTime += stopwatch.Elapsed.TotalMilliseconds;
            }

            return (totalTime / iterations) / 1000.0;
        }

        // Метод для измерения времени выполнения сортировки (SortingAlgorithm)
        public double MeasureExecutionTimeSorting(SortingAlgorithm algorithm, int iterations, int[] data)
        {
            Stopwatch stopwatch = new Stopwatch();
            double totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                int[] dataCopy = (int[])data.Clone(); // Чтобы сортировать новый массив на каждом шаге
                stopwatch.Restart();
                algorithm.Sort(dataCopy); // Запуск сортировки
                stopwatch.Stop();
                totalTime += stopwatch.Elapsed.TotalMilliseconds;
            }

            return (totalTime / iterations) / 1000.0;
        }
        
        // Метод для измерения времени выполнения матричной операции (умножение матриц)
        public double MeasureExecutionTimeMatrix(Func<int[,], int[,], int> matrixOperation, int iterations, int[,] matrix1, int[,] matrix2)
        {
            Stopwatch stopwatch = new Stopwatch();
            double totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                stopwatch.Restart();
                int result = matrixOperation(matrix1, matrix2); // Запуск матричной операции, возвращающей одно число
                stopwatch.Stop();
                totalTime += stopwatch.Elapsed.TotalMilliseconds;
            }

            return (totalTime / iterations) / 1000.0;
        }
    }