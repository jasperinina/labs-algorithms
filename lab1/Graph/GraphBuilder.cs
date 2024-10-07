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
        
        // Настройка максимальных значений осей (динамически)
        wpfPlot.Plot.Axes.Left.Max = timeResults.Max();
        wpfPlot.Plot.Axes.Bottom.Max = sizes.Max();

        
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
        
        // Настройка максимальных значений осей (динамически)
        wpfPlot.Plot.Axes.Left.Max = stepResults.Max();
        wpfPlot.Plot.Axes.Bottom.Max = exponents.Max();

        
        wpfPlot.Refresh();
    }
    
    public void PlotStringLengthVsSteps(double[] stringLengths, double[] stepResults)
    {
        wpfPlot.Plot.Clear();

        // Добавляем график (размер строки vs шаги)
        wpfPlot.Plot.Add.Scatter(stringLengths, stepResults);

        // Устанавливаем метки осей
        wpfPlot.Plot.XLabel("Длина строки");
        wpfPlot.Plot.YLabel("Количество шагов");

        // Настройка осей
        wpfPlot.Plot.Axes.Left.Min = 0; // Минимальное значение по оси Y
        wpfPlot.Plot.Axes.Bottom.Min = 0; // Минимальное значение по оси X
    
        // Настройка максимальных значений осей (динамически)
        wpfPlot.Plot.Axes.Left.Max = stepResults.Max();
        wpfPlot.Plot.Axes.Bottom.Max = stringLengths.Max();

        // Обновляем график
        wpfPlot.Refresh();
    }
}
