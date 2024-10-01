using Algorithm;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class StringTester
{
    private AutoTesterString tester = new AutoTesterString();
        
    private List<int> stringLengths = new List<int>();
    private List<int> steps = new List<int>();

    // Метод для тестирования поиска подстрок
    public void Test(string algorithm, int maxStringLength, int substringLength, int stepSize)
    {
        stringLengths.Clear();
        steps.Clear();

        if (algorithm == "Алгоритм Бойера-Мура-Хорспула")
        {
            var stringResults = tester.TestSubstringSearch(
                length => new DataGenerator().GenerateString(length),
                (text, pattern) =>
                {
                    var bmhPersonal = new AlgorithmBMHPersonal(text, pattern);
                    return bmhPersonal.GetIndexes(text, pattern);
                },
                maxStringLength, substringLength, stepSize
            );
            StoreResults(stringResults);
        }
    }

    // Метод для сохранения данных для графика
    private void StoreResults(List<(int StringLength, int Steps)> results)
    {
        foreach (var result in results)
        {
            stringLengths.Add(result.StringLength);
            steps.Add(result.Steps);
        }
    }

    // Метод для получения длин строк для графика
    public double[] GetStringLengths()
    {
        return stringLengths.Select(sl => (double)sl).ToArray();
    }

    // Метод для получения шагов для графика
    public double[] GetSteps()
    {
        return steps.Select(s => (double)s).ToArray();
    }
}