namespace Graph.Logic.Sorting_Algorithms;

public class TimSort : SortingAlgorithm
{
    // Сортировка TimSort
    private static int MIN_MERGE = 32;

    public override void Sort(int[] array)
    {
        // Выполняем сортировку вставками на подмассивах размером MIN_MERGE
        InsertionSort insertionSort = new InsertionSort();
        
        for (int i = 0; i < array.Length; i += MIN_MERGE)
        {
            insertionSort.Sort(array);
        }

        // Выполняем слияние отсортированных подмассивов
        Merge merge = new Merge();
        
        for (int size = MIN_MERGE; size < array.Length; size *= 2)
        {
            for (int left = 0; left < array.Length; left += 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min(left + 2 * size - 1, array.Length - 1);
                
                if (mid < right)
                {
                    merge.MergeSort(array, left, mid, right);
                }
            }
        }
    }
}