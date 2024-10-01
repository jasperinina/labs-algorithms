namespace Graph.Logic.Mathematical_Operations.Pow_Operation;

public class QuickPowClassic : PowerOperation
{
    // Быстрое возведение в степень с подсчетом шагов
    public override (long result, int steps) CalculatePower(int x, int n)
    {
        long result = 1;
        int steps = 0; 

        while (n > 0)
        {
            steps++; 

            if (n % 2 == 1)
            {
                result *= x;
            }
            x *= x;
            n /= 2;
        }

        return (result, steps); 
    }
}