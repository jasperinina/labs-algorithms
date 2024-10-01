namespace Graph.Logic.Mathematical_Operations.Basic_Operation;

public class ConstFunction : BasicOperation
{
    // Возвращение последнего элемента массива
    public override long PerformOperation(params int[] args)
    {
        return args[args.Length - 1];
    }
}