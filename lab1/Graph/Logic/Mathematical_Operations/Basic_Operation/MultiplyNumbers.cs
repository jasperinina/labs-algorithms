namespace Graph.Logic.Mathematical_Operations.Basic_Operation;

public class MultiplyNumbers : BasicOperation
{
    // Умножение элементов массива
    public override long PerformOperation(params int[] args)
    {
        int result = args[0];
        for (int i = 1; i < args.Length; i++)
        {
            result *= args[i];
        }
        return result;
    }
}