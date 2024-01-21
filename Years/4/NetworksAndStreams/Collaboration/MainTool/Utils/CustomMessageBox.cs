using MainTool.ViewModels;
using MainTool.Views;

namespace MainTool.Utils
{
    public static class CustomMessageBox
    {
        public static void Show(string title, string message)
        {
            new CustomMessageBoxWindow(new CustomMessageBoxViewModel(title, message)).ShowDialog();
        }

        public static void ShowAnimated(string title, string message)
        {
            new AnimatedMessageBoxWindow(new CustomMessageBoxViewModel(title, message)).ShowDialog();
        }
    }
}