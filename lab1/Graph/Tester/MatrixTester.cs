using Algorithm;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class MatrixTester
{
    private AutoTesterOther tester = new AutoTesterOther();

    public string Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        string resultText = "";

        if (algorithm == "MatrixMultiply")
        {
            MatrixOperations matrixOps = new MatrixOperations();
            var matrixResults = tester.TestMatrixOperation(matrixOps.MatrixMultiply, maxData, stepSize, repetitions);
            resultText = FormatResults(matrixResults);
        }

        return resultText;
    }

    private string FormatResults(List<(int size, double averageTime)> results)
    {
        string resultText = "";
        foreach (var result in results)
        {
            resultText += $"Размер матрицы: {result.size}, Среднее время: {result.averageTime} мс\n";
        }
        return resultText;
    }
}
