using ScottPlot.WPF;

namespace Graph;

public class GraphBuilder
{
    private WpfPlot wpfPlot;

    // Конструктор, принимающий WpfPlot
    public GraphBuilder(WpfPlot plot)
    {
        this.wpfPlot = plot;
    }

    // Метод для построения графика времени vs. размера данных
    public void PlotTimeVsDataSize(double[] sizes, double[] timeResults)
    {
        // Очищаем предыдущие графики
        wpfPlot.Plot.Clear();

        // Добавляем scatter график
        wpfPlot.Plot.Add.Scatter(sizes, timeResults);

        // Устанавливаем названия осей
        wpfPlot.Plot.XLabel("Размер данных");
        wpfPlot.Plot.YLabel("Время (секунды)");
        
        wpfPlot.Plot.Axes.Left.Min = 0;
        wpfPlot.Plot.Axes.Left.Max = 1;
        
        wpfPlot.Plot.Axes.Bottom.Min = 0;
        wpfPlot.Plot.Axes.Bottom.Max = 1000;

        // Обновляем график
        wpfPlot.Refresh();
    }

    // Метод для построения графика шагов vs. степени
    public void PlotStepsVsExponent(double[] exponents, double[] stepResults)
    {
        // Очищаем предыдущие графики
        wpfPlot.Plot.Clear();

        // Добавляем scatter график
        wpfPlot.Plot.Add.Scatter(exponents, stepResults);

        // Устанавливаем названия осей
        wpfPlot.Plot.XLabel("Степень");
        wpfPlot.Plot.YLabel("Количество шагов");
        
        wpfPlot.Plot.Axes.Left.Min = 0;
        wpfPlot.Plot.Axes.Left.Max = 100;
        
        wpfPlot.Plot.Axes.Bottom.Min = 0;
        wpfPlot.Plot.Axes.Bottom.Max = 50000;

        // Обновляем график
        wpfPlot.Refresh();
    }
}