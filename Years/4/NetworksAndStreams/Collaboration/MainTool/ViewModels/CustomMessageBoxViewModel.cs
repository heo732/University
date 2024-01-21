using System;
using System.Windows;

using MainTool.WPF;

namespace MainTool.ViewModels
{
    public class CustomMessageBoxViewModel : BindableBase
    {
        public event EventHandler WindowDrag;

        public CustomMessageBoxViewModel(string title, string message)
        {
            WindowTitle = title;
            Message = message;
            WindowDragCommand = new DelegateCommand(WindowDragAction);
            WindowMaximizeCommand = new DelegateCommand(WindowMaximizeAction);
        }

        public string WindowTitle { get; }

        public string Message { get; }

        public WindowState WindowState
        {
            get => windowState;
            set
            {
                windowState = value;
                RaisePropertyChanged(nameof(WindowState));
            }
        }

        public SizeToContent WindowSizeToContent
        {
            get => windowSizeToContent;
            set
            {
                windowSizeToContent = value;
                RaisePropertyChanged(nameof(WindowSizeToContent));
            }
        }

        public DelegateCommand WindowDragCommand { get; }

        public DelegateCommand WindowMaximizeCommand { get; }

        private void WindowDragAction()
        {
            WindowDrag?.Invoke(this, null);
        }

        private void WindowMaximizeAction()
        {
            if (WindowSizeToContent != SizeToContent.Manual)
            {
                WindowSizeToContent = SizeToContent.Manual;
            }

            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private WindowState windowState = WindowState.Normal;
        private SizeToContent windowSizeToContent = SizeToContent.WidthAndHeight;
    }
}