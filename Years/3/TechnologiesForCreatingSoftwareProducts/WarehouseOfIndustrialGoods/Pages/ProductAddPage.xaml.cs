using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WarehouseOfIndustrialGoods.Models;

namespace WarehouseOfIndustrialGoods.Pages
{
    /// <summary>
    /// Interaction logic for ProductAddPage.xaml
    /// </summary>
    public partial class ProductAddPage : Page
    {
        #region Constructors

        public ProductAddPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            WindowTitle = "Додавання нового продукту";
        }

        #endregion Constructors

        #region Properties

        private MainWindow MainWindow { get; }

        #endregion Properties

        #region Methods

        private void ProductAddBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SwitchPage("Products");
        }

        private async void ProductAddConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if ((productAddNameTextBox.Text.Length == 0) || productAddNameTextBox.Text.All(c => c == ' '))
            {
                AddingResultAnimation(Colors.Red);
                MessageBox.Show("Ім'я продукту не може бути порожнім або складатися лише із пробілів.");
                return;
            }

            if (await MainWindow.DB.Products.FirstOrDefaultAsync(p => p.Name == productAddNameTextBox.Text) != null)
            {
                AddingResultAnimation(Colors.Red);
                MessageBox.Show("Продукт із таким ім'ям вже є у таблиці.");
                return;
            }

            try
            {
                MainWindow.DB.Products.Add(new Product() { Name = productAddNameTextBox.Text });
                await MainWindow.DB.SaveChangesAsync();
                AddingResultAnimation(Colors.Green);
            }
            catch (Exception ex)
            {
                AddingResultAnimation(Colors.Red);
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductAddClearButton_Click(object sender, RoutedEventArgs e)
        {
            productAddNameTextBox.Text = string.Empty;
        }

        private void AddingResultAnimation(Color targetColor)
        {
            productAddNameTextBox.Background = new SolidColorBrush(Colors.White);

            var animation = new ColorAnimation()
            {
                From = Colors.White,
                To = targetColor,
                Duration = new Duration(TimeSpan.FromMilliseconds(2000))
            };
            productAddNameTextBox.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);

            animation.From = animation.To;
            animation.To = Colors.White;

            productAddNameTextBox.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        #endregion Methods
    }
}