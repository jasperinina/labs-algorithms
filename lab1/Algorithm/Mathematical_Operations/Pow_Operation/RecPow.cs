namespace Algorithm.Mathematical_Operations.Pow_Operation;

public class RecPow : PowerOperation
{
    // Метод для рекурсивного возведения в степень с подсчетом шагов
    public override (long result, int steps) CalculatePower(int x, int n)
    {
        int steps = 0;
        return (RecursivePower(x, n, ref steps), steps);
    }

    private long RecursivePower(int x, int n, ref int steps)
    {
        steps++; 

        if (n == 0)
            return 1;
            
        long half = RecursivePower(x, n / 2, ref steps);
        if (n % 2 == 0)
            return half * half;
        else
            return half * half * x;
    }
}