using Algorithm.Mathematical_Operations.Polynomial_Operation;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class PolynomialTester
{
    private AutoTesterOther tester = new AutoTesterOther();

    public string Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        string resultText = "";

        if (algorithm == "HornerPolynomial")
        {
            HornerPolynomial hornerPolynomial = new HornerPolynomial();
            var polyResults = tester.TestPolynomialOperation(hornerPolynomial, maxData, stepSize, repetitions);
            resultText = FormatResults(polyResults);
        }
        else if (algorithm == "NaivePolynomial")
        {
            NaivePolynomial naivePolynomial = new NaivePolynomial();
            var polyResults = tester.TestPolynomialOperation(naivePolynomial, maxData, stepSize, repetitions);
            resultText = FormatResults(polyResults);
        }

        return resultText;
    }

    private string FormatResults(List<(int size, double averageTime)> results)
    {
        string resultText = "";
        foreach (var result in results)
        {
            resultText += $"Размер полинома: {result.size}, Среднее время: {result.averageTime} мс\n";
        }
        return resultText;
    }
}
