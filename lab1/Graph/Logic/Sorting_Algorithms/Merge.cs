namespace Graph.Logic.Sorting_Algorithms;

public class Merge
{
    // Вспомогательный метод для TimSort, класс для слияния подмассивов
    public void MergeSort(int[] array, int left, int middle, int right)
    {
        int len1 = middle - left + 1;
        int len2 = right - middle;
        int[] leftArray = new int[len1];
        int[] rightArray = new int[len2];
            
        for (int a = 0; a < len1; a++)
            leftArray[a] = array[left + a];
            
        for (int b = 0; b < len2; b++)
            rightArray[b] = array[middle + 1 + b];

        int i = 0, j = 0, k = left;
        
        while (i < len1 && j < len2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }
            
        while (i < len1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }
            
        while (j < len2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}