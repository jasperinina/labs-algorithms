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
        wpfPlot.Plot.Clear();
        
        wpfPlot.Plot.Add.Scatter(sizes, timeResults);
        
        wpfPlot.Plot.XLabel("Размер данных");
        wpfPlot.Plot.YLabel("Время (секунды)");
        
        wpfPlot.Plot.Axes.Left.Min = 0;
        wpfPlot.Plot.Axes.Left.Max = 1;
        
        wpfPlot.Plot.Axes.Bottom.Min = 0;
        wpfPlot.Plot.Axes.Bottom.Max = 1000;
        
        wpfPlot.Refresh();
    }

    // Метод для построения графика шагов vs. степени
    public void PlotStepsVsExponent(double[] exponents, double[] stepResults)
    {
        wpfPlot.Plot.Clear();
        
        wpfPlot.Plot.Add.Scatter(exponents, stepResults);
        
        wpfPlot.Plot.XLabel("Степень");
        wpfPlot.Plot.YLabel("Количество шагов");
        
        wpfPlot.Plot.Axes.Left.Min = 0;
        wpfPlot.Plot.Axes.Left.Max = 100;
        
        wpfPlot.Plot.Axes.Bottom.Min = 0;
        wpfPlot.Plot.Axes.Bottom.Max = 50000;
        
        wpfPlot.Refresh();
    }
}