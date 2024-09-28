namespace Algorithm.Mathematical_Operations.Pow_Operation;

public abstract class PowerOperation
{
    // Базовый метод для операций возведения в степень
    public abstract (long result, int steps) CalculatePower(int x, int n);
}