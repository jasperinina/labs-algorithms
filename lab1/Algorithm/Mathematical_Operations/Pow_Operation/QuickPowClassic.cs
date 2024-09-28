namespace Algorithm.Mathematical_Operations.Pow_Operation;

public class QuickPowClassic : PowerOperation
{
    // Быстрое возведение в степень с подсчетом шагов
    public override (long result, int steps) CalculatePower(int x, int n)
    {
        long result = 1;
        int steps = 0; // Счетчик шагов

        while (n > 0)
        {
            steps++; // Увеличиваем количество шагов

            if (n % 2 == 1)
            {
                result *= x;
            }
            x *= x;
            n /= 2;
        }

        return (result, steps); // Возвращаем результат и количество шагов
    }
}
    