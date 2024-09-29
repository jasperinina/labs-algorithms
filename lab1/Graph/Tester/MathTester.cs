using Algorithm.Mathematical_Operations.Basic_Operation;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class MathTester
{
    private AutoTesterOther tester = new AutoTesterOther();

    public string Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        string resultText = "";

        if (algorithm == "ConstFunction")
        {
            ConstFunction constFunction = new ConstFunction();
            var mathResults = tester.TestBasicOperation(constFunction, maxData, stepSize, repetitions);
            resultText = FormatResults(mathResults);
        }
        else if (algorithm == "SumNumbers")
        {
            SumNumbers sumNumbers = new SumNumbers();
            var mathResults = tester.TestBasicOperation(sumNumbers, maxData, stepSize, repetitions);
            resultText = FormatResults(mathResults);
        }
        else if (algorithm == "MultiplyNumbers")
        {
            MultiplyNumbers multiplyNumbers = new MultiplyNumbers();
            var mathResults = tester.TestBasicOperation(multiplyNumbers, maxData, stepSize, repetitions);
            resultText = FormatResults(mathResults);
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
