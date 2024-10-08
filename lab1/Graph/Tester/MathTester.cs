﻿using Algorithm.Test_Algorithms.Auto_Testing;
using Graph.Logic.Mathematical_Operations.Basic_Operation;

namespace Graph.Tester;

public class MathTester
{
    private AutoTesterOther tester = new AutoTesterOther();
    
    private List<int> dataSizes = new List<int>();
    private List<double> times = new List<double>();

    public void Test(string algorithm, int maxData, int stepSize, int repetitions)
    {
        dataSizes.Clear();
        times.Clear();

        if (algorithm == "Постоянная функция")
        {
            ConstFunction constFunction = new ConstFunction();
            var mathResults = tester.TestBasicOperation(constFunction, maxData, stepSize, repetitions);
            StoreResults(mathResults);
        }
        else if (algorithm == "Сумма элементов")
        {
            SumNumbers sumNumbers = new SumNumbers();
            var mathResults = tester.TestBasicOperation(sumNumbers, maxData, stepSize, repetitions);
            StoreResults(mathResults);
        }
        else if (algorithm == "Умножение элементов")
        {
            MultiplyNumbers multiplyNumbers = new MultiplyNumbers();
            var mathResults = tester.TestBasicOperation(multiplyNumbers, maxData, stepSize, repetitions);
            StoreResults(mathResults);
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