using Algorithm.Sorting_Algorithms;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class SortingTester
{
    private AutoTesterOther tester = new AutoTesterOther();
    
    private List<int> dataSizes = new List<int>();
    private List<double> times = new List<double>();

    public void Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        dataSizes.Clear();
        times.Clear();

        if (algorithm == "Сортировка пузырьком")
        {
            BubbleSort bubbleSort = new BubbleSort();
            var sortResults = tester.TestSortingOperation(bubbleSort, maxData, stepSize, repetitions);
            StoreResults(sortResults);
        }
        else if (algorithm == "Быстрая сортировка")
        {
            QuickSort quickSort = new QuickSort();
            var sortResults = tester.TestSortingOperation(quickSort, maxData, stepSize, repetitions);
            StoreResults(sortResults);
        }
        else if (algorithm == "Гибридная сортировка")
        {
            TimSort timSort = new TimSort();
            var sortResults = tester.TestSortingOperation(timSort, maxData, stepSize, repetitions);
            StoreResults(sortResults);
        }
        else if (algorithm == "Блинная Сортировка")
        {
            PancakeSortPersonal timSort = new PancakeSortPersonal();
            var sortResults = tester.TestSortingOperation(timSort, maxData, stepSize, repetitions);
            StoreResults(sortResults);
        }
    }

    // Метод для сохранения данных для графика
    private void StoreResults(List<(int size, double averageTime)> results)
    {
        foreach (var result in results)
        {
            dataSizes.Add(result.size);
            times.Add(result.averageTime);
        }
    }

    // Метод для получения размеров данных для графика
    public double[] GetDataSizes()
    {
        return dataSizes.Select(s => (double)s).ToArray();
    }

    // Метод для получения времени выполнения для графика
    public double[] GetTimes()
    {
        return times.ToArray();
    }
}