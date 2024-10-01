namespace Graph.Logic.Mathematical_Operations.Pow_Operation;

public class QuickPowFaster : PowerOperation
{
    // Оптимизированное быстрое возведение в степень с подсчетом шагов
    public override (long result, int steps) CalculatePower(int x, int n)
    {
        long result = 1;
        int steps = 0;

        if (n % 2 == 1)
        {
            result = x;
        }

        while (n > 0)
        {
            steps++; 
            n /= 2;
            x *= x;

            if (n % 2 == 1)
            {
                result *= x;
            }
        }

        return (result, steps);
    }
}