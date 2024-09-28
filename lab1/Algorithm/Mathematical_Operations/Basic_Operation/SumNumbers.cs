namespace Algorithm.Mathematical_Operations.Basic_Operation;

public class SumNumbers : BasicOperation
{
    // Суммирование элементов массива
    public override long PerformOperation(params int[] args)
    {
        int result = args[0];
        for (int i = 1; i < args.Length; i++)
        {
            result += args[i];
        }
        return result;
    }
}