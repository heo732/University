using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;

using MainTool.ViewModels;

namespace MainTool.Views
{
    public partial class CustomMessageBoxWindow : Window
    {
        public CustomMessageBoxWindow(CustomMessageBoxViewModel viewModel)
        {
            var windowInteropHelper = new WindowInteropHelper(this)
            {
                Owner = Process.GetCurrentProcess().MainWindowHandle
            };

            InitializeComponent();

            DataContext = viewModel;
            viewModel.WindowDrag += (sender, args) => DragMove();
        }
    }
}