using Algorithm.Sorting_Algorithms;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class SortingTester
{
    private AutoTesterOther tester = new AutoTesterOther();

    public string Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        string resultText = "";

        if (algorithm == "Bubble sort")
        {
            BubbleSort bubbleSort = new BubbleSort();
            var sortResults = tester.TestSortingOperation(bubbleSort, maxData, stepSize, repetitions);
            resultText = FormatResults(sortResults);
        }
        else if (algorithm == "Quick sort")
        {
            QuickSort quickSort = new QuickSort();
            var sortResults = tester.TestSortingOperation(quickSort, maxData, stepSize, repetitions);
            resultText = FormatResults(sortResults);
        }
        else if (algorithm == "TimSort")
        {
            TimSort timSort = new TimSort();
            var sortResults = tester.TestSortingOperation(timSort, maxData, stepSize, repetitions);
            resultText = FormatResults(sortResults);
        }

        return resultText;
    }

    private string FormatResults(List<(int size, double averageTime)> results)
    {
        string resultText = "";
        foreach (var result in results)
        {
            resultText += $"Размер: {result.size}, Среднее время: {result.averageTime} мс\n";
        }
        return resultText;
    }
}
