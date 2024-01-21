using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GeneticAlgorithm.FitnessFunction fitnessFunction;

        private void DrawFunctionGraphic()
        {
            // добавим данные линии
            var axisXData = new List<double>();
            var axisYData = new List<double>();
            for (double i = -100.0; i <= 100.0; i += 0.1)
            {
                axisXData.Add(i);
                axisYData.Add(fitnessFunction(i));
            }
            chart.Series["Series1"].Points.DataBindXY(axisXData, axisYData);
        }

        public MainWindow()
        {
            InitializeComponent();

            comboBoxFunction.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Все графики находятся в пределах области построения ChartArea, создадим ее
            chart.ChartAreas.Add(new ChartArea("Default"));

            chart.ChartAreas["Default"].AxisX.Interval = 5.0;
            chart.ChartAreas["Default"].AxisX.Maximum = 100.0;
            chart.ChartAreas["Default"].AxisX.Minimum = -100.0;

            // Добавим линию, и назначим ее в ранее созданную область "Default"
            chart.Series.Add(new Series("Series1"));
            chart.Series["Series1"].ChartArea = "Default";
            chart.Series["Series1"].ChartType = SeriesChartType.Line;
            chart.Series["Series1"].BorderWidth = 2;

            DrawFunctionGraphic();
        }

        private void ComboBoxFunction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        fitnessFunction = new GeneticAlgorithm.FitnessFunction((double x) =>
                        {
                            return -2.0 * Math.Pow(x, 2) - 1.0;
                        });
                        break;
                    }
                case 1:
                    {
                        fitnessFunction = new GeneticAlgorithm.FitnessFunction((double x) =>
                        {
                            if (-80.0 <= x && x < -45.0)
                                return Math.Cos(x * 0.5) * Math.Exp(x * 0.1) * 10E3;
                            if (-45.0 <= x && x < -10.0)
                                return 2.0 * x + 80.0;
                            if (-10.0 <= x && x < 20.0)
                                return Math.Pow(x - 2.0, 2) * 0.6 - 30.0;
                            if (20.0 <= x && x < 80.0)
                                return Math.Sin(x * 0.7) * Math.Exp(x * 0.1) * 0.03;
                            
                            return 0.0;
                        });
                        break;
                    }
                case 2:
                    {
                        fitnessFunction = new GeneticAlgorithm.FitnessFunction((double x) =>
                        {
                            if (-63.0 <= x && x < -50.0)
                                return Math.Pow(x + 50.0, 2) * -0.1 + 29.0;
                            if (-50.0 <= x && x < -10.0)
                                return Math.Pow(x + 30.0, 2) * 0.03 + 17.0;
                            if (-10.0 <= x && x < 10.0)
                                return Math.Pow(x, 2) * 0.1 + 30.0;
                            if (10.0 <= x && x < 50.0)
                                return Math.Pow(x - 30.0, 2) * 0.03 + 17.0;
                            if (50.0 <= x && x < 63.0)
                                return Math.Pow(x - 50.0, 2) * -0.1 + 29.0;

                            return 10.0;
                        });
                        break;
                    }
            }

            if (this.IsLoaded)
                DrawFunctionGraphic();
        }

        private void button_Search_Click(object sender, RoutedEventArgs e)
        {   
            bool working = true;
            

            label_ResultArticle.Content = "";
            GeneticAlgorithm geneticAlgorithm = null;
            try
            {
                geneticAlgorithm = new GeneticAlgorithm((int)numericUpDown_populationSize.Value,
                    (int)numericUpDown_numberOfGenesInChromosome.Value, (double)numericUpDown_probabilityCrossover.Value,
                    (double)numericUpDown_probabilityMutation.Value, (double)numericUpDown_borderLeft.Value,
                    (double)numericUpDown_borderRight.Value, fitnessFunction);
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
                working = false;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.ParamName, ex.Message);
                working = false;
            }

            if (working)
            {
                label_ResultArticle.Content = "Пошук . . .";

                double swTime = 0.0;
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                int generation = 0;
                int limitGeneration = (int)numericUpDown_limitGeneration.Value;
                double limitTime = (double)numericUpDown_limitTime.Value;
                double x = 0.0;
                double yMax = double.MinValue;
                while (generation < limitGeneration && swTime < limitTime)
                {
                    geneticAlgorithm.NextGeneration();
                    generation++;

                    double tempX = geneticAlgorithm.GetPhenotypeOfMaxAdaptedPerson();
                    double tempY = fitnessFunction(tempX);

                    if (tempY > yMax)
                    {
                        x = tempX;
                        yMax = tempY;
                    }

                    swTime = sw.ElapsedMilliseconds / 1000.0;
                }
                

                label_ResultArticle.Content = "Знайдено максимум функції в точці";
                
                label_ResultPoint.Content = "(" + x.ToString() + "; " + yMax.ToString() + ")";

                working = false;

                sw.Stop();
                label_ResultTime.Content = "Час виконання:  " + swTime.ToString();
            }
        }

        private void numericUpDown_borderLeft_ValueChanged(object sender, EventArgs e)
        {
            if (this.IsLoaded)
            {
                long len = (long)(numericUpDown_borderRight.Value - numericUpDown_borderLeft.Value);
                long value = 1;
                int step = 0;
                while (value < len)
                {
                    value *= 2;
                    step++;
                }
                label_recomendNumberOfGenesInChromosome.Content = "Рекомендовано:  " + step.ToString();
            }
        }
    }
}
