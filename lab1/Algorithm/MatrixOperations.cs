namespace Algorithm;

public class MatrixOperations
{
    // Метод для умножения двух матриц
    public int MatrixMultiply(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int innerDim = matrix1.GetLength(1);
        int[,] resultMatrix = new int[rows, cols];

        // Умножаем матрицы и сохраняем в resultMatrix
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int k = 0; k < innerDim; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        // Рассчитываем сумму всех элементов результирующей матрицы
        int scalarResult = 0;
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                scalarResult += resultMatrix[i, j];
            }
        }

        return scalarResult; // Возвращаем одно число
    }
}