using Algorithm.Sorting_Algorithms;
using Algorithm.Test_Algorithms;
using Algorithm.Mathematical_Operations.Basic_Operation;
using Algorithm.Mathematical_Operations.Polynomial_Operation;

namespace Algorithm.Test_Algorithm.Auto_Testing;

public class AutoTesterOther
    {
        private TimeTrackerOther timeTracker;
        private DataGenerator dataGenerator;

        // Конструктор
        public AutoTesterOther()
        {
            timeTracker = new TimeTrackerOther();
            dataGenerator = new DataGenerator();
        }

        // Метод для тестирования базовой операции
        public List<(int size, double averageTime)> TestBasicOperation(BasicOperation operation, int maxSize, int stepSize, int iterations)
        {
            var results = new List<(int size, double averageTime)>();

            for (int size = stepSize; size <= maxSize; size += stepSize)
            {
                int[] data = dataGenerator.ArrayGenerate(size, 100);

                // Измерение времени выполнения базовой операции
                double averageTime = timeTracker.MeasureExecutionTimeBasic(operation, iterations, data);
                results.Add((size, averageTime));
            }

            return results;
        }

        // Метод для тестирования полиномов
        public List<(int size, double averageTime)> TestPolynomialOperation(PolynomialOperations operation, int maxSize, int stepSize, int iterations)
        {
            var results = new List<(int size, double averageTime)>();

            for (int size = stepSize; size <= maxSize; size += stepSize)
            {
                double[] coefficients = dataGenerator.GeneratePolynomialCoefficients(size, 100.0);

                // Измерение времени выполнения полиномиальной операции
                double averageTime = timeTracker.MeasureExecutionTimePolynomial(operation, iterations, 1.5, coefficients);
                results.Add((size, averageTime));
            }

            return results;
        }

        // Метод для тестирования сортировки
        public List<(int size, double averageTime)> TestSortingOperation(SortingAlgorithm algorithm, int maxSize, int stepSize, int iterations)
        {
            var results = new List<(int size, double averageTime)>();

            for (int size = stepSize; size <= maxSize; size += stepSize)
            {
                int[] data = dataGenerator.ArrayGenerate(size, 100);

                // Измерение времени выполнения сортировки
                double averageTime = timeTracker.MeasureExecutionTimeSorting(algorithm, iterations, data);
                results.Add((size, averageTime));
            }

            return results;
        }
        
        // Метод для тестирования матричных операций (умножение матриц)
        public List<(int size, double averageTime)> TestMatrixOperation(Func<int[,], int[,], int> matrixOperation, int maxSize, int stepSize, int iterations)
        {
            var results = new List<(int size, double averageTime)>();

            for (int size = stepSize; size <= maxSize; size += stepSize)
            {
                int[,] matrix1 = dataGenerator.MatrixGenerate(size, 100); 
                int[,] matrix2 = dataGenerator.MatrixGenerate(size, 100); 

                // Измерение времени выполнения матричной операции, возвращающей одно число
                double averageTime = timeTracker.MeasureExecutionTimeMatrix((m1, m2) => matrixOperation(m1, m2), iterations, matrix1, matrix2);
                results.Add((size, averageTime));
            }

            return results;
        }
    }