using System.Windows;

using MainTool.ViewModels;

namespace MainTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            viewModel.WindowDrag += (sender, args) => DragMove();
            viewModel.WindowClose += (sender, args) => Close();
            viewModel.GraphZoomToFill += (sender, args) => graphZoom.ZoomToFill();
        }
    }
}