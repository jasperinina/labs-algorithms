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
        private StringTester stringTester = new StringTester();
        
        private double[] dataSizes;
        private double[] times;
        private double[] exponents;
        private double[] steps;

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация GraphBuilder с передачей WpfPlot
            graphBuilder = new GraphBuilder(wpfPlot);
            
            // Подписываемся на событие Loaded для инициализации после загрузки окна
            this.Loaded += MainWindow_Loaded;
        }
        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Sorting";
            PopulateAlgorithmComboBox();
        }

        // Метод для заполнения выпадающего списка алгоритмов в зависимости от выбранной категории
        private void PopulateAlgorithmComboBox()
        {
            // Проверка, что ComboBox инициализирован
            if (AlgorithmComboBox == null)
            {
                throw new NullReferenceException("AlgorithmComboBox не инициализирован.");
            }
            
            AlgorithmComboBox.Items.Clear();
            
            if (selectedCategory == "Sorting")
            {
                AlgorithmComboBox.Items.Add("Сортировка пузырьком");
                AlgorithmComboBox.Items.Add("Быстрая сортировка");
                AlgorithmComboBox.Items.Add("Гибридная сортировка");
                AlgorithmComboBox.Items.Add("Блинная cортировка");
                AlgorithmComboBox.Items.Add("Сортировка бинарным деревом");
            }
            else if (selectedCategory == "Math")
            {
                AlgorithmComboBox.Items.Add("Постоянная функция");
                AlgorithmComboBox.Items.Add("Сумма Элементов");
                AlgorithmComboBox.Items.Add("Умножение элементов");
            }
            else if (selectedCategory == "Matrix")
            {
                AlgorithmComboBox.Items.Add("Умножение матриц");
            }
            else if (selectedCategory == "Power")
            {
                AlgorithmComboBox.Items.Add("Простое взведение");
                AlgorithmComboBox.Items.Add("Рекурсивное возведение");
                AlgorithmComboBox.Items.Add("Быстрое возведение");
                AlgorithmComboBox.Items.Add("Классическое быстрое возведение");
                
            }
            else if (selectedCategory == "Polynomial")
            {
                AlgorithmComboBox.Items.Add("Прямое вычисление");
                AlgorithmComboBox.Items.Add("Схема горнера");
            }
            else if (selectedCategory == "StringSearch")
            {
                AlgorithmComboBox.Items.Add("Алгоритм Бойера-Мура-Хорспула");
            }


            // Устанавливаем первый элемент как выбранный
            AlgorithmComboBox.SelectedIndex = 0;
        }

        // Обработчики для RadioButton выбора категорий
        private void SortingRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Sorting";
            if (AlgorithmComboBox != null)
            {
                PopulateAlgorithmComboBox();
            }
        }

        private void MathRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Math";
            if (AlgorithmComboBox != null)
            {
                PopulateAlgorithmComboBox();
            }
        }
        
        private void MatrixRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Matrix";
            if (AlgorithmComboBox != null)
            {
                PopulateAlgorithmComboBox();
            }
        }

        private void PowerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Power";
            if (AlgorithmComboBox != null)
            {
                PopulateAlgorithmComboBox();
            }
        }

        private void PolynomialRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategory = "Polynomial";
            if (AlgorithmComboBox != null)
            {
                PopulateAlgorithmComboBox();
            }
        }
        
        private void StringSearchRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategory = "StringSearch";
            if (AlgorithmComboBox != null)
            {
                PopulateAlgorithmComboBox();
            }
        }
        
        // Показ полей ввода данных, когда выбран конкретный алгоритм
        private void AlgorithmComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AlgorithmComboBox.SelectedIndex >= 0)
            {
                selectedAlgorithm = AlgorithmComboBox.SelectedItem.ToString();
                
                // Очистка полей ввода данных
                MaxDataTextBox.Clear();
                RepetitionsTextBox.Clear();
                StepSizeTextBox.Clear();
                
                if (selectedCategory == "Power")
                {
                    FirstTextBlock.Text = "Максимальная степень";
                    SecondTextBlock.Text = "Основание степени";
                    ThirdextBlock.Text = "Шаг увеличения степени";
                }
                else if (selectedCategory == "StringSearch")
                {
                    FirstTextBlock.Text = "Максимальная длинна строки";
                    SecondTextBlock.Text = "Длина подстроки";
                    ThirdextBlock.Text = "Шаг увеличения строки";
                }

                else
                {
                    FirstTextBlock.Text = "Максимальное количество данных";
                    SecondTextBlock.Text = "Количество повторов";
                    ThirdextBlock.Text = "Шаг увеличения данных";
                }
            }
        }

        // Обновляем метод обработки результатов
        private void StartTestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Очищаем область графиков
                wpfPlot.Plot.Clear();

                switch (selectedCategory)
                {
                    case "Sorting":
                        sortingTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                        dataSizes = sortingTester.GetDataSizes();
                        times = sortingTester.GetTimes();
                        graphBuilder.PlotTimeVsDataSize(dataSizes, times);
                        break;

                    case "Math":
                        mathTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                        dataSizes = mathTester.GetDataSizes();
                        times = mathTester.GetTimes();
                        graphBuilder.PlotTimeVsDataSize(dataSizes, times);
                        break;

                    case "Power":
                        powerTester.Test(selectedAlgorithm, GetBaseValue(), GetMaxExponent(), GetExponentStep());
                        exponents = powerTester.GetExponents();
                        steps = powerTester.GetSteps();
                        graphBuilder.PlotStepsVsExponent(exponents, steps);
                        break;

                    case "Polynomial":
                        polynomialTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                        dataSizes = polynomialTester.GetDataSizes();
                        times = polynomialTester.GetTimes();
                        graphBuilder.PlotTimeVsDataSize(dataSizes, times);
                        break;
                    
                    case "Matrix":
                        matrixTester.Test(selectedAlgorithm, GetMaxData(), GetStepSize(), GetRepetitions());
                        dataSizes = matrixTester.GetDataSizes();
                        times = matrixTester.GetTimes();
                        graphBuilder.PlotTimeVsDataSize(dataSizes, times);
                        break;
                    
                    case "StringSearch":
                        stringTester.Test(selectedAlgorithm, GetStringLength(), GetSubstringLength(), GetLengthStep());
                        dataSizes = stringTester.GetStringLengths();
                        steps = stringTester.GetSteps();
                        graphBuilder.PlotStringLengthVsSteps(dataSizes, steps);
                        break;
                    
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        // Методы для получения данных из текстовых полей
        private int GetMaxData()
        {
            if (int.TryParse(MaxDataTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для максимального количества данных");
        }

        private int GetStepSize()
        {
            if (int.TryParse(StepSizeTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для шага увеличения данных");
        }

        private int GetRepetitions()
        {
            if (int.TryParse(RepetitionsTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для количества повторов");
        }

        // Методы для степенных операций
        private int GetBaseValue()
        {
            if (int.TryParse(RepetitionsTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для основания степени");
        }

        private int GetMaxExponent()
        {
            if (int.TryParse(MaxDataTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для максимальной степени");
        }

        private int GetExponentStep()
        {
            if (int.TryParse(StepSizeTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для шага увеличения степени");
        }
        
        // Методы для степенных операций
        private int GetSubstringLength()
        {
            if (int.TryParse(RepetitionsTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для длинны подстроки");
        }

        private int GetStringLength()
        {
            if (int.TryParse(MaxDataTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для максимальной длинны строки");
        }

        private int GetLengthStep()
        {
            if (int.TryParse(StepSizeTextBox.Text, out int result))
                return result;
            else
                throw new ArgumentException("Некорректный ввод для шага увеличения строки");
        }
    }
}