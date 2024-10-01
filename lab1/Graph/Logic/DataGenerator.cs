namespace Graph.Logic;

public class DataGenerator
{
    private Random rnd = new Random();

    // Метод для заполнения существующей матрицы случайными значениями
    public void MatrixFill(int[,] matrix, int maxRandomValue)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rnd.Next(maxRandomValue);
            }
        }
    }

    // Метод для генерации новой матрицы с заданной размерностью и заполнения случайными числами
    public int[,] MatrixGenerate(int matrixDim, int maxRandomValue)
    {
        int[,] matrix = new int[matrixDim, matrixDim];
        
        MatrixFill(matrix, maxRandomValue);
        
        return matrix;
    }

    // Метод для генерации одномерного массива случайных чисел
    public int[] ArrayGenerate(int arrayLength, int maxRandomValue)
    {
        int[] array = new int[arrayLength];
        
        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = rnd.Next(maxRandomValue);
        }
        
        return array;
    }
    
    // Метод для генерации случайных коэффициентов многочлена
    public double[] GeneratePolynomialCoefficients(int size, double maxRandomValue)
    {
        double[] coefficients = new double[size];
        
        for (int i = 0; i < size; i++)
        {
            coefficients[i] = rnd.NextDouble() * maxRandomValue; // Коэффициенты от 0 до maxRandomValue
        }
        
        return coefficients;
    }

    // Метод для генерации случайных строк длины lenght
    public string GenerateString(int length)
    {
        string alf = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ0123456789!@#$%^&*()"; // Алфавит для создания рандомной строки
        char[] stringChars = new char[length];
        
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = alf[rnd.Next(alf.Length)];
        }
        
        return new string(stringChars);
    }
}