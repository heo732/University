using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using WarehouseOfIndustrialGoods.Models;
using WarehouseOfIndustrialGoods.Pages;

namespace WarehouseOfIndustrialGoods
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties

        public static WarehouseOfIndustrialGoodsContext DB { get; } = new WarehouseOfIndustrialGoodsContext();

        public Dictionary<string, Page> Pages { get; }

        #endregion Properties

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            Pages = new Dictionary<string, Page>
            {
                { "Main", new MainPage(this) },
                { "Products", new  ProductsPage(this)},
                { "ProductAdd", new  ProductAddPage(this)},
                { "ProductEdit", new  ProductEditPage(this)}
            };

            SwitchPage("Main");
        }

        #endregion Constructors

        #region Methods

        public void SwitchPage(string page)
        {
            Content = Pages[page];
        }

        public void SetTargetElementInProductEditPage(Product product)
        {
            (Pages["ProductEdit"] as ProductEditPage).TargetElement = product;
            (Pages["ProductEdit"] as ProductEditPage).productEditNameTextBox.Text = product.Name;
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            DB.Consumers.Load();
            DB.Employees.Load();
            DB.Preparations.Load();
            DB.Products.Load();
            DB.ProductMovings.Load();
            DB.Shipments.Load();
            DB.Suppliers.Load();
            DB.Supplies.Load();
            DB.WarehousePlaces.Load();
        }

        #endregion Methods
    }
}