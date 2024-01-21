using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WarehouseOfIndustrialGoods.Models;

namespace WarehouseOfIndustrialGoods.Pages
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        #region Constructors

        public ProductsPage(MainWindow mainWindow)
        {
            InitializeComponent();
            WindowTitle = "Продукти";
            MainWindow = mainWindow;
            productsListView.ItemsSource = MainWindow.DB.Products.Local.ToBindingList();
        }

        #endregion Constructors

        #region Properties

        private MainWindow MainWindow { get; }

        #endregion Properties

        #region Methods

        private void ProductsBackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.SwitchPage("Main");
        }

        #endregion Methods

        private void ProductsAddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.SwitchPage("ProductAdd");
        }

        private async void ProductsRemoveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (productsListView.SelectedItems.Count < 1)
            {
                MessageBox.Show("Спочатку оберіть записи для видалення");
                return;
            }

            var removeText = new StringBuilder();
            removeText.AppendLine("Ви дійсно бажаєте видалити наступні записи:");
            removeText.AppendLine();
            var removeCollection = new List<Product>();
            foreach (Product item in productsListView.SelectedItems)
            {
                removeText.AppendLine(string.Format("[{0}] {1}", item.Id, item.Name));
                removeCollection.Add(item);
            }

            if (MessageBox.Show(removeText.ToString(), "Підтвердження операції", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.DB.Products.RemoveRange(removeCollection);
                    await MainWindow.DB.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ProductsEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (productsListView.SelectedItem == null)
            {
                MessageBox.Show("Оберіть запис для редагування");
                return;
            }

            MainWindow.SwitchPage("ProductEdit");
            MainWindow.SetTargetElementInProductEditPage(productsListView.SelectedItem as Product);
        }
    }
}