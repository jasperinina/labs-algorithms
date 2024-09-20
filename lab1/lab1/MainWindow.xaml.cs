using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using Algorithms;

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (obj, e) =>
            {
                var sw = new Stopwatch();
                List<int> data = new List<int>();
                List<long> time = new List<long>();
                for (int i = 1; i < 20000; i += 2000)
                {
                    int[] array = algorithm.ArrayGenerate(i);
                    sw.Start();
                    algorithm.Sum_numbers(array);
                    sw.Stop();
                    data.Add(i);
                    time.Add(sw.ElapsedTicks);
                    sw.Reset();
                }
                Grafic.Plot.Add.Scatter(data, time);
                Grafic.Refresh();
            };
        }
    }
}
