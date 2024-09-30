namespace Algorithm.Mathematical_Operations.Pow_Operation;

public class SimplePow : PowerOperation
{
    // Линейное возведение в степень
    public override (long result, int steps) CalculatePower(int x, int n)
    {
        long result = 1;
        int steps = 0; // Счетчик шагов

        for (int i = 0; i < n; i++)
        {
            result *= x;
            steps++; // Увеличиваем количество шагов
        }

        return (result, steps); // Возвращаем результат и количество шагов
    }
}
