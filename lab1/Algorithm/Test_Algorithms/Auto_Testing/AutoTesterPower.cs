namespace Algorithm.Test_Algorithms.Auto_Testing;

public class AutoTesterPower
{
    private List<int> exponents = new List<int>();
    private List<int> steps = new List<int>();

    // Метод для автоматического тестирования степенных операций
    public List<(int Exponent, int Steps)> TestPowerOperation(Func<int, int, (long result, int steps)> powerOperation, int maxExponent, int stepSize, int baseValue)
    {
        var results = new List<(int Exponent, int Steps)>();

        for (int exponent = 1; exponent <= maxExponent; exponent += stepSize)
        {
            var (_, stepCount) = powerOperation(baseValue, exponent);
            results.Add((exponent, stepCount));

            // Сохраняем данные для построения графиков
            exponents.Add(exponent);
            steps.Add(stepCount);
        }

        return results;
    }
}