namespace Algorithm.Test_Algorithms.Auto_Testing;

public class AutoTesterPower
{
    // Метод для автоматического тестирования степенных операций
    public List<(int Exponent, int Steps)> TestPowerOperation(Func<int, int, (long result, int steps)> powerOperation, int maxExponent, int stepSize, int baseValue)
    {
        var results = new List<(int Exponent, int Steps)>();

        for (int exponent = stepSize; exponent <= maxExponent; exponent += stepSize)
        {
            var (_, steps) = powerOperation(baseValue, exponent); // Выполняем алгоритм возведения в степень и получаем количество шагов
            results.Add((exponent, steps));
        }

        return results;
    }

}