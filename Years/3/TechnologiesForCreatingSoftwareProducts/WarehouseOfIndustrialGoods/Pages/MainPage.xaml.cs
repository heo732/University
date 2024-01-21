using System.Windows;
using System.Windows.Controls;

namespace WarehouseOfIndustrialGoods.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        #region Constructors

        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            WindowTitle = "Склад - промислові товари";
            MainWindow = mainWindow;
        }

        #endregion Constructors

        #region Properties

        private MainWindow MainWindow { get; }

        #endregion Properties

        #region Methods

        private void SuppliesButton_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        #endregion Methods

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SwitchPage("Products");
        }
    }
}