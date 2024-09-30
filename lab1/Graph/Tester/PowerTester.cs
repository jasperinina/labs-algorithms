using Algorithm.Mathematical_Operations.Pow_Operation;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class PowerTester
{
    private AutoTesterPower tester = new AutoTesterPower();

    // Списки для хранения данных для графиков
    private List<int> exponents = new List<int>();
    private List<int> steps = new List<int>();

    public void Test(string algorithm, int baseValue, int maxExponent, int exponentStep)
    {
        // Очищаем предыдущие данные
        exponents.Clear();
        steps.Clear();

        if (algorithm == "SimplePow")
        {
            SimplePow simplePow = new SimplePow();
            var powerResults = tester.TestPowerOperation(simplePow.CalculatePower, maxExponent, exponentStep, baseValue);
            StoreResults(powerResults);
        }
        else if (algorithm == "RecPow")
        {
            RecPow recPow = new RecPow();
            var powerResults = tester.TestPowerOperation(recPow.CalculatePower, maxExponent, exponentStep, baseValue);
            StoreResults(powerResults);
        }
        else if (algorithm == "QuickPowFaster")
        {
            QuickPowFaster quickPowFaster = new QuickPowFaster();
            var powerResults = tester.TestPowerOperation(quickPowFaster.CalculatePower, maxExponent, exponentStep, baseValue);
            StoreResults(powerResults);
        }
        else if (algorithm == "QuickPowClassic")
        {
            QuickPowClassic quickPowClassic = new QuickPowClassic();
            var powerResults = tester.TestPowerOperation(quickPowClassic.CalculatePower, maxExponent, exponentStep, baseValue);
            StoreResults(powerResults);
        }
    }

    // Метод для сохранения данных для графика
    private void StoreResults(List<(int Exponent, int Steps)> results)
    {
        foreach (var result in results)
        {
            exponents.Add(result.Exponent);
            steps.Add(result.Steps);
        }
    }

    // Метод для получения степеней для графика
    public double[] GetExponents()
    {
        return exponents.Select(e => (double)e).ToArray();
    }

    // Метод для получения шагов для графика
    public double[] GetSteps()
    {
        return steps.Select(s => (double)s).ToArray();
    }
}
