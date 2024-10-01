namespace Graph.Logic.Sorting_Algorithms;

public class QuickSort : SortingAlgorithm
{
    // Быстрая сортировка
    public override void Sort(int[] array)
    {
        Quicksort(array, 0, array.Length - 1);
    }

    private void Quicksort(int[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }
            
            if (i <= j)
            {
                (array[i], array[j]) = (array[j], array[i]);
                
                i++;
                j--;
            }
        }
        
        if (leftIndex < j)
            Quicksort(array, leftIndex, j);
        if (i < rightIndex)
            Quicksort(array, i, rightIndex);
    }
}