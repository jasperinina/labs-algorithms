using Algorithm.Mathematical_Operations.Basic_Operation;
using Algorithm.Mathematical_Operations.Polynomial_Operation;
using Algorithm.Sorting_Algorithms;

namespace Algorithm.Test_Algorithms.Auto_Testing;

public class AutoTesterOther
{
    private TimeTrackerOther timeTracker;
    private DataGenerator dataGenerator;

    private List<int> dataSizes = new List<int>();  // Список для хранения размеров данных
    private List<double> times = new List<double>();  // Список для хранения времени выполнения

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

            // Измерение времени
            double averageTime = timeTracker.MeasureExecutionTimeBasic(operation, iterations, data);
            results.Add((size, averageTime));

            // Сохраняем данные для графика
            dataSizes.Add(size);
            times.Add(averageTime);
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

            // Измерение времени
            double averageTime = timeTracker.MeasureExecutionTimePolynomial(operation, iterations, 1.5, coefficients);
            results.Add((size, averageTime));

            // Сохраняем данные для графика
            dataSizes.Add(size);
            times.Add(averageTime);
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

            // Измерение времени
            double averageTime = timeTracker.MeasureExecutionTimeSorting(algorithm, iterations, data);
            results.Add((size, averageTime));

            // Сохраняем данные для графика
            dataSizes.Add(size);
            times.Add(averageTime);
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

            // Измерение времени
            double averageTime = timeTracker.MeasureExecutionTimeMatrix((m1, m2) => matrixOperation(m1, m2), iterations, matrix1, matrix2);
            results.Add((size, averageTime));

            // Сохраняем данные для графика
            dataSizes.Add(size);
            times.Add(averageTime);
        }

        return results;
    }
}