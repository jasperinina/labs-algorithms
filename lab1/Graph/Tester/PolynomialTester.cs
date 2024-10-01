using Algorithm.Mathematical_Operations.Polynomial_Operation;
using Algorithm.Test_Algorithms.Auto_Testing;

namespace Graph.Tester;

public class PolynomialTester
{
    private AutoTesterOther tester = new AutoTesterOther();
    
    private List<int> dataSizes = new List<int>();
    private List<double> times = new List<double>();

    public void Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        dataSizes.Clear();
        times.Clear();

        if (algorithm == "Схема Горнера")
        {
            HornerPolynomial hornerPolynomial = new HornerPolynomial();
            var polyResults = tester.TestPolynomialOperation(hornerPolynomial, maxData, stepSize, repetitions);
            StoreResults(polyResults);
        }
        else if (algorithm == "Прямое вычисление")
        {
            NaivePolynomial naivePolynomial = new NaivePolynomial();
            var polyResults = tester.TestPolynomialOperation(naivePolynomial, maxData, stepSize, repetitions);
            StoreResults(polyResults);
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