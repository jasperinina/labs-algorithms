namespace Graph.Logic.Sorting_Algorithms;

public class BubbleSort : SortingAlgorithm
{
    // Сортировка пузырьком
    public override void Sort(int[] array)
    {
        int temp;
        
        for (int j = 0; j < array.Length - 1; j++)
        {
            for (int i = 0; i < array.Length - j - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }
        }
    }
}