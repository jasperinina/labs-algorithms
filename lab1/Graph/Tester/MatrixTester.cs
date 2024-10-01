using Algorithm.Test_Algorithms.Auto_Testing;
using Graph.Logic;

namespace Graph.Tester;

public class MatrixTester
{
    private AutoTesterOther tester = new AutoTesterOther();
    
    private List<int> dataSizes = new List<int>();
    private List<double> times = new List<double>();

    public void Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        dataSizes.Clear();
        times.Clear();

        if (algorithm == "Умножение матриц")
        {
            MatrixOperations matrixOps = new MatrixOperations();
            var matrixResults = tester.TestMatrixOperation(matrixOps.MatrixMultiply, maxData, stepSize, repetitions);
            StoreResults(matrixResults);
        }
    }

    // Метод для сохранения данных для графика
    private void StoreResults(List<(int size, double averageTime)> results)
    {
        foreach (var result in results)
        {
            dataSizes.Add(result.size);
            times.Add(result.averageTime);
        }
    }

    // Метод для получения размеров данных для графика
    public double[] GetDataSizes()
    {
        return dataSizes.Select(s => (double)s).ToArray();
    }

    // Метод для получения времени выполнения для графика
    public double[] GetTimes()
    {
        return times.ToArray();
    }
}