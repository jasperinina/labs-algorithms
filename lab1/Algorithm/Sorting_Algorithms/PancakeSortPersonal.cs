namespace Algorithm.Sorting_Algorithms;

public class PancakeSortPersonal : SortingAlgorithm
{
    public override void Sort(int[] array)
    {
        int n = array.Length;
        // Проходим по всему массиву, уменьшая размер неотсортированной части
        for (int curr_size = n; curr_size > 1; curr_size--)
        {
            // Находим индекс максимального элемента в текущей неотсортированной части
            int maxIndex = FindMax(array, curr_size);

            // Если максимальный элемент не на своем месте, перемещаем его
            if (maxIndex != curr_size - 1)
            {
                // Если максимальный элемент не первый, переворачиваем массив до него
                if (maxIndex != 0)
                {
                    Flip(array, maxIndex);
                }
                // Переворачиваем текущую неотсортированную часть, чтобы максимальный элемент встал на место
                Flip(array, curr_size - 1);
            }
        }
    }

    // Метод для переворота массива от 0 до k
    private void Flip(int[] array, int k)
    {
        int start = 0;
        while (start < k)
        {
            (array[start], array[k]) = (array[k], array[start]);
            start++;
            k--;
        }
    }

    // Метод для поиска индекса максимального элемента в массиве[0..n-1]
    private int FindMax(int[] array, int n)
    {
        int maxIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }
}