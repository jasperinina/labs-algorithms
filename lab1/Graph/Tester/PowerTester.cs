using Algorithm.Mathematical_Operations.Pow_Operation;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class PowerTester
{
    private AutoTesterPower tester = new AutoTesterPower();

    public string Test(string algorithm, int baseValue, int maxExponent, int exponentStep)
    {
        string resultText = "";

        if (algorithm == "SimplePow")
        {
            SimplePow simplePow = new SimplePow();
            var powerResults = tester.TestPowerOperation(simplePow.CalculatePower, maxExponent, exponentStep, baseValue);
            resultText = FormatResults(powerResults);
        }
        else if (algorithm == "RecPow")
        {
            RecPow recPow = new RecPow();
            var powerResults = tester.TestPowerOperation(recPow.CalculatePower, maxExponent, exponentStep, baseValue);
            resultText = FormatResults(powerResults);
        }
        else if (algorithm == "QuickPowFaster")
        {
            QuickPowFaster quickPowFaster = new QuickPowFaster();
            var powerResults = tester.TestPowerOperation(quickPowFaster.CalculatePower, maxExponent, exponentStep, baseValue);
            resultText = FormatResults(powerResults);
        }
        else if (algorithm == "QuickPowClassic")
        {
            QuickPowClassic quickPowClassic = new QuickPowClassic();
            var powerResults = tester.TestPowerOperation(quickPowClassic.CalculatePower, maxExponent, exponentStep, baseValue);
            resultText = FormatResults(powerResults);
        }

        return resultText;
    }

    private string FormatResults(List<(int Exponent, int Steps)> results)
    {
        string resultText = "";
        foreach (var result in results)
        {
            resultText += $"Степень: {result.Exponent}, Количество шагов: {result.Steps}\n";
        }
        return resultText;
    }
}
