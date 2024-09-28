using Algorithm.Mathematical_Operations.Pow_Operation;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Algorithm;

class Program
{
    static void Main()
    {
        /*
        // Использование базовых операций
        BasicOperation constFunc = new ConstFunction();
        Console.WriteLine(constFunc.PerformOperation(1, 2, 3, 4)); // Вернет 4

        BasicOperation sumNumbers = new SumNumbers();
        Console.WriteLine(sumNumbers.PerformOperation(1, 2, 3, 4)); // Вернет 10

        BasicOperation multiplyNumbers = new MultiplyNumbers();
        Console.WriteLine(multiplyNumbers.PerformOperation(1, 2, 3, 4)); // Вернет 24

        // Использование степенных операций
        PowerOperation simplePow = new SimplePow();
        Console.WriteLine(simplePow.CalculatePower(2, 10)); // Вернет 1024

        PowerOperation recPow = new RecPow();
        Console.WriteLine(recPow.CalculatePower(2, 10)); // Вернет 1024

        PowerOperation quickPowFaster = new QuickPowFaster();
        Console.WriteLine(quickPowFaster.CalculatePower(2, 10)); // Вернет 1024

        PowerOperation quickPowClassic = new QuickPowClassic();
        Console.WriteLine(quickPowClassic.CalculatePower(2, 10)); // Вернет 1024
        */

        /*
        int[] array = { 4, 2, 7, 1, 9, 3 };

        // Пузырьковая сортировка
        SortingAlgorithm bubbleSort = new BubbleSort();
        bubbleSort.Sort(array);
        Console.WriteLine("BubbleSort: " + string.Join(", ", array));

        // Быстрая сортировка
        array = new int[] { 4, 2, 7, 1, 9, 3 };
        SortingAlgorithm quickSort = new QuickSort();
        quickSort.Sort(array);
        Console.WriteLine("QuickSort: " + string.Join(", ", array));

        // Сортировка вставками
        array = new int[] { 4, 2, 7, 1, 9, 3 };
        SortingAlgorithm insertionSort = new InsertionSort();
        insertionSort.Sort(array);
        Console.WriteLine("InsertionSort: " + string.Join(", ", array));

        // TimSort
        array = new int[] { 4, 2, 7, 1, 9, 3 };
        SortingAlgorithm timSort = new TimSort();
        timSort.Sort(array);
        Console.WriteLine("TimSort: " + string.Join(", ", array));
        */

        /*
        DataGenerator generator = new DataGenerator();
        MatrixOperations matrixOps = new MatrixOperations();

        // Генерация двух матриц 3x3 с максимальными значениями до 100 через DataGenerator
        int[,] matrix1 = generator.MatrixGenerate(3, 100);
        int[,] matrix2 = generator.MatrixGenerate(3, 100);

        // Умножение матриц и получение одного числа
        int resultScalar = matrixOps.MatrixMultiplyToScalar(matrix1, matrix2);

        // Вывод результата
        Console.WriteLine("Результат умножения матриц: " + resultScalar);
        */

        /*
        // Коэффициенты многочлена v1, v2, v3,...vn
        double[] coefficients = { 1.0, 2.0, 3.0, 4.0 }; // Многочлен 1 + 2x + 3x^2 + 4x^3

        // Наивное вычисление
        PolynomialOperations naivePoly = new NaivePolynomial();
        double naiveResult = naivePoly.Evaluate(1.5, coefficients);
        Console.WriteLine("Наивное вычисление P(1.5): " + naiveResult);

        // Вычисление методом Горнера
        PolynomialOperations hornerPoly = new HornerPolynomial();
        double hornerResult = hornerPoly.Evaluate(1.5, coefficients);
        Console.WriteLine("Метод Горнера P(1.5): " + hornerResult);
        */

        /*
        AutoTesterOther tester = new AutoTesterOther();
        MatrixOperations matrixOps = new MatrixOperations();

        // Пример тестирования умножения матриц
        List<(int size, double averageTime)> matrixResults = tester.TestMatrixOperation(matrixOps.MatrixMultiply, 500, 100, 10);

        // Вывод результатов тестирования матриц
        foreach (var result in matrixResults)
        {
            Console.WriteLine($"Matrix Operation: Size = {result.size}, Avg Time = {result.averageTime} ms");
        }
        */

        
        AutoTesterPower tester = new AutoTesterPower();

        // Инициализация алгоритмов возведения в степень
        SimplePow simplePow = new SimplePow();
        RecPow recPow = new RecPow();
        QuickPowClassic quickPow = new QuickPowClassic();
        QuickPowFaster quickPowFaster = new QuickPowFaster();

        // Тестирование алгоритма SimplePow
        List<(int exponent, int steps)> simplePowResults = tester.TestPowerOperation(simplePow.CalculatePower, 1000, 100, 2);

        // Тестирование алгоритма RecPow
        List<( int exponent, int steps)> recPowResults = tester.TestPowerOperation(recPow.CalculatePower, 1000, 100, 2);

        // Тестирование алгоритма QuickPowClassic
        List<(int exponent, int steps)> quickPowResults = tester.TestPowerOperation(quickPow.CalculatePower, 1000, 100, 2);

        // Тестирование алгоритма QuickPowFaster
        List<(int exponent, int steps)> quickPowFasterResults = tester.TestPowerOperation(quickPowFaster.CalculatePower, 1000, 100, 2);

        // Вывод результатов
        foreach (var result in simplePowResults)
        {
            Console.WriteLine($"SimplePow: Степень = {result.exponent}, Шаги = {result.steps}");
        }

        foreach (var result in recPowResults)
        {
            Console.WriteLine($"RecPow: Степень = {result.exponent}, Шаги = {result.steps}");
        }

        foreach (var result in quickPowResults)
        {
            Console.WriteLine($"QuickPowClassic: Степень = {result.exponent}, Шаги = {result.steps}");
        }

        foreach (var result in quickPowFasterResults)
        {
            Console.WriteLine($"QuickPowFaster: Степень = {result.exponent}, Шаги = {result.steps}");
        }
        
    }
}
