using System.Windows;
using Graph.Tester;

namespace Graph
{
    public partial class MainWindow : Window
    {
        private string selectedCategory = "";
        private string selectedAlgorithm = "";

        private GraphBuilder graphBuilder;
        private SortingTester sortingTester = new SortingTester();
        private MathTester mathTester = new MathTester();
        private MatrixTester matrixTester = new MatrixTester();
        private PowerTester powerTester = new PowerTester();
        private PolynomialTester polynomialTester = new PolynomialTester();

        // Добавляем поля для хранения данных
        private double[] dataSizes;
        private double[] times;
        private double[] exponents;
        private double[] steps;

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация GraphBuilder с передачей WpfPlot
            graphBuilder = new GraphBuilder(wpfPlot);
        }

        // Метод для заполнения выпадающего списка алгоритмов в зависимости от выбранной категории
        private void PopulateAlgorithmComboBox()
        {
            // Очищаем выпадающий список алгоритмов перед добавлением новых элементов
            AlgorithmComboBox.Items.Clear();

            // В зависимости от выбранной категории (selectedCategory) добавляем алгоритмы
            if (selectedCategory == "Sorting")
            {
                AlgorithmComboBox.Items.Add("Bubble sort");
                AlgorithmComboBox.Items.Add("Quick sort");
                AlgorithmComboBox.Items.Add("TimSort");
            }
            else if (selectedCategory == "Math")
            {
                AlgorithmComboBox.Items.Add("ConstFunction");
                AlgorithmComboBox.Items.Add("SumNumbers");
                AlgorithmComboBox.Items.Add("MultiplyNumbers");
            }
            else if (selectedCategory == "Matrix")
            {
                AlgorithmComboBox.Items.Add("MatrixMultiply");
            }
            else if (selectedCategory == "Power")
            {
                AlgorithmComboBox.Items.Add("SimplePow");
                AlgorithmComboBox.Items.Add("RecPow");
                AlgorithmComboBox.Items.Add("QuickPowFaster");
                AlgorithmComboBox.Items.Add("QuickPowClassic");
            }
            else if (selectedCategory == "Polynomial")
            {
                AlgorithmComboBox.Items.Add("HornerPolynomial");
                AlgorithmComboBox.Items.Add("NaivePolynomial");
            }

            // Устанавливаем первый элемент как выбранный
            AlgorithmComboBox.SelectedIndex = 0;
        }

        // Обработчики кнопок выбора категорий
        private void SortingButton_Click(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Sorting";
            PopulateAlgorithmComboBox();
            HideInputFields();
        }

        private void MathButton_Click(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Math";
            PopulateAlgorithmComboBox();
            HideInputFields();
        }

        private void MatrixButton_Click(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Matrix";
            PopulateAlgorithmComboBox();
            HideInputFields();
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Power";
            PopulateAlgorithmComboBox();
            HideInputFields();
        }

        private void PolynomialButton_Click(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Polynomial";
            PopulateAlgorithmComboBox();
            HideInputFields();
        }

        // Метод для скрытия полей ввода до выбора алгоритма
        private void HideInputFields()
        {
            InputFieldsPanel.Visibility = Visibility.Collapsed;
            BaseTextBox.Visibility = Visibility.Collapsed;
            MaxExponentTextBox.Visibility = Visibility.Collapsed;
            ExponentStepTextBox.Visibility = Visibility.Collapsed;
        }

        // Показ полей ввода данных, когда выбран конкретный алгоритм
        private void AlgorithmComboBox_SelectionChanged(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AlgorithmComboBox.SelectedIndex >= 0)
            {
                selectedAlgorithm = AlgorithmComboBox.SelectedItem.ToString();
                InputFieldsPanel.Visibility = Visibility.Visible;

                // Показ полей для степеней, если выбрана категория степенных алгоритмов
                if (selectedCategory == "Power")
                {
                    BaseTextBox.Visibility = Visibility.Visible;
                    MaxExponentTextBox.Visibility = Visibility.Visible;
                    ExponentStepTextBox.Visibility = Visibility.Visible;

                    MaxDataTextBox.Visibility = Visibility.Collapsed;
                    RepetitionsTextBox.Visibility = Visibility.Collapsed;
                    StepSizeTextBox.Visibility = Visibility.Collapsed;

                    MaxDataTextBlock.Visibility = Visibility.Collapsed;
                    RepetitionsTextBlock.Visibility = Visibility.Collapsed;
                    StepSizeTextBlock.Visibility = Visibility.Collapsed;

                    BaseTextBlock.Visibility = Visibility.Visible;
                    MaxExponentTextBlock.Visibility = Visibility.Visible;
                    ExponentStepTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    // Для всех остальных категорий (сортировка, математика, матрицы) показываем обычные поля
                    MaxDataTextBox.Visibility = Visibility.Visible;
                    RepetitionsTextBox.Visibility = Visibility.Visible;
                    StepSizeTextBox.Visibility = Visibility.Visible;

                    BaseTextBox.Visibility = Visibility.Collapsed;
                    MaxExponentTextBox.Visibility = Visibility.Collapsed;
                    ExponentStepTextBox.Visibility = Visibility.Collapsed;

                    MaxDataTextBlock.Visibility = Visibility.Visible;
                    RepetitionsTextBlock.Visibility = Visibility.Visible;
                    StepSizeTextBlock.Visibility = Visibility.Visible;

                    BaseTextBlock.Visibility = Visibility.Collapsed;
                    MaxExponentTextBlock.Visibility = Visibility.Collapsed;
                    ExponentStepTextBlock.Visibility = Visibility.Collapsed;
                }
            }
        }

        // Обновляем метод обработки результатов
        private void StartTestButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем область графиков
            wpfPlot.Plot.Clear();

            switch (selectedCategory)
            {
                case "Sorting":
                    sortingTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                    dataSizes = sortingTester.GetDataSizes();
                    times = sortingTester.GetTimes();
                    graphBuilder.PlotTimeVsDataSize(dataSizes, times); // Построение графика времени vs. размера данных
                    break;

                case "Math":
                    mathTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                    dataSizes = mathTester.GetDataSizes();
                    times = mathTester.GetTimes();
                    graphBuilder.PlotTimeVsDataSize(dataSizes, times); // Построение графика времени vs. размера данных
                    break;

                case "Power":
                    powerTester.Test(selectedAlgorithm, GetBaseValue(), GetMaxExponent(), GetExponentStep());
                    exponents = powerTester.GetExponents();
                    steps = powerTester.GetSteps();
                    graphBuilder.PlotStepsVsExponent(exponents, steps); // Построение графика шагов vs. степени
                    break;

                case "Polynomial":
                    polynomialTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                    dataSizes = polynomialTester.GetDataSizes();
                    times = polynomialTester.GetTimes();
                    graphBuilder.PlotTimeVsDataSize(dataSizes, times); // Построение графика времени vs. размера данных
                    break;

                case "Matrix":
                    matrixTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                    dataSizes = matrixTester.GetDataSizes();
                    times = matrixTester.GetTimes();
                    graphBuilder.PlotTimeVsDataSize(dataSizes, times); // Построение графика времени vs. размера данных
                    break;
            }


        }

        // Методы для получения данных из текстовых полей
            private int GetMaxData() => int.Parse(MaxDataTextBox.Text);
            private int GetStepSize() => int.Parse(StepSizeTextBox.Text);
            private int GetRepetitions() => int.Parse(RepetitionsTextBox.Text);

            private int GetBaseValue() => int.Parse(BaseTextBox.Text);
            private int GetMaxExponent() => int.Parse(MaxExponentTextBox.Text);
            private int GetExponentStep() => int.Parse(ExponentStepTextBox.Text);
    }
}



