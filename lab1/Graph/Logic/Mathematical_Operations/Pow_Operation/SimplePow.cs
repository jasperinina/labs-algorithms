namespace Graph.Logic.Mathematical_Operations.Pow_Operation;

public class SimplePow : PowerOperation
{
    // Линейное возведение в степень
    public override (long result, int steps) CalculatePower(int x, int n)
    {
        long result = 1;
        int steps = 0; 
        
        for (int i = 0; i < n; i++)
        {
            result *= x;
            steps++; 
        }

        return (result, steps); 
    }
}