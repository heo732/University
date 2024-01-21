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
    /// Interaction logic for ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        #region Constructors

        public ProductEditPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            WindowTitle = "Редагування запису продукту";
        }

        #endregion Constructors

        #region Properties

        public Product TargetElement { get; set; }
        private MainWindow MainWindow { get; }

        #endregion Properties

        #region Methods

        private async void ProductEditConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if ((productEditNameTextBox.Text.Length == 0) || productEditNameTextBox.Text.All(c => c == ' '))
            {
                EditResultAnimation(Colors.Red);
                MessageBox.Show("Ім'я продукту не може бути порожнім або складатися лише із пробілів.");
                return;
            }

            if (await MainWindow.DB.Products.FirstOrDefaultAsync(p => p.Name == productEditNameTextBox.Text) != null)
            {
                EditResultAnimation(Colors.Red);
                MessageBox.Show("Продукт із таким ім'ям вже є у таблиці.");
                return;
            }

            try
            {
                Product findProduct = MainWindow.DB.Products.FirstOrDefault(p => p.Name == TargetElement.Name);
                findProduct.Name = TargetElement.Name;
                MainWindow.DB.Entry(findProduct).State = EntityState.Modified;
                await MainWindow.DB.SaveChangesAsync();
                EditResultAnimation(Colors.Green);
            }
            catch (Exception ex)
            {
                EditResultAnimation(Colors.Red);
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductEditBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SwitchPage("Products");
        }

        private void EditResultAnimation(Color targetColor)
        {
            productEditNameTextBox.Background = new SolidColorBrush(Colors.White);

            var animation = new ColorAnimation()
            {
                From = Colors.White,
                To = targetColor,
                Duration = new Duration(TimeSpan.FromMilliseconds(2000))
            };
            productEditNameTextBox.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);

            animation.From = animation.To;
            animation.To = Colors.White;

            productEditNameTextBox.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        #endregion Methods
    }
}