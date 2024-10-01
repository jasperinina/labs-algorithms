using System;
using System.Collections.Generic;
using Algorithm.Sorting_Algorithms;
using Algorithm.Mathematical_Operations.Basic_Operation;
using Algorithm.Mathematical_Operations.Pow_Operation;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов для тестирования
            AutoTesterOther tester = new AutoTesterOther();
            MatrixOperations matrixOps = new MatrixOperations();
            BubbleSort bubbleSort = new BubbleSort();
            QuickSort quickSort = new QuickSort();
            RecPow recPow = new RecPow();
            BasicOperation multiplyOperation = new MultiplyNumbers();
            AutoTesterPower testerPower = new AutoTesterPower();
            
            // Тестирование базовой операции умножения
            Console.WriteLine("Тестирование базовой операции умножения:");
            var basicOpResults = tester.TestBasicOperation(multiplyOperation, maxSize: 100, stepSize: 10, iterations: 5);
            foreach (var result in basicOpResults)
            {
                Console.WriteLine($"Размер: {result.size}, Среднее время: {result.averageTime} мс");
            }

            // Тестирование сортировки пузырьком
            Console.WriteLine("\nТестирование пузырьковой сортировки:");
            var bubbleSortResults = tester.TestSortingOperation(bubbleSort, maxSize: 10000, stepSize: 1000, iterations: 5);
            foreach (var result in bubbleSortResults)
            {
                Console.WriteLine($"Размер: {result.size}, Среднее время: {result.averageTime} мс");
            }

            // Тестирование быстрой сортировки
            Console.WriteLine("\nТестирование быстрой сортировки:");
            var quickSortResults = tester.TestSortingOperation(quickSort, maxSize: 10000, stepSize: 100, iterations: 5);
            foreach (var result in quickSortResults)
            {
                Console.WriteLine($"Размер: {result.size}, Среднее время: {result.averageTime} мс");
            }

            // Тестирование возведения в степень
            Console.WriteLine("\nТестирование рекурсивного возведения в степень:");
            var powerTestResults = testerPower.TestPowerOperation(recPow.CalculatePower, maxExponent: 100, stepSize: 10, baseValue: 2);
            foreach (var result in powerTestResults)
            {
                Console.WriteLine($"Степень: {result.Exponent}, Количество шагов: {result.Steps}");
            }

            // Тестирование умножения матриц
            Console.WriteLine("\nТестирование умножения матриц:");
            var matrixTestResults = tester.TestMatrixOperation(matrixOps.MatrixMultiply, maxSize: 50, stepSize: 10, iterations: 5);
            foreach (var result in matrixTestResults)
            {
                Console.WriteLine($"Размер матрицы: {result.size}, Среднее время: {result.averageTime} мс");
            }
            
            AutoTesterString autoTester = new AutoTesterString();

            // Тестирование поиска подстроки
            List<(int StringLength, int Steps)> results = autoTester.TestSubstringSearch(
                stringGenerationOperation: length => new DataGenerator().GenerateString(length),
                substringSearchOperation: (text, pattern) => new AlgorithmBMHPersonal(text, pattern).GetIndexes(text, pattern), 100, 20, 10);
            
            Console.WriteLine("\nТестирование поиска подстроки:");
            foreach (var result in results)
            {
                Console.WriteLine($"Длина строки: {result.StringLength}, Количество шагов: {result.Steps}");
            }
            
            Console.WriteLine("\nТестирование завершено.");
        }
    }
}