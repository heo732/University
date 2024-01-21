using MainTool.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Animation;

namespace MainTool.Views
{
    public partial class AnimatedMessageBoxWindow : Window
    {
        public AnimatedMessageBoxWindow(CustomMessageBoxViewModel viewModel)
        {
            var windowInteropHelper = new WindowInteropHelper(this)
            {
                Owner = Process.GetCurrentProcess().MainWindowHandle
            };

            InitializeComponent();

            DataContext = viewModel;

            var duration = TimeSpan.FromMilliseconds(750);
            Loaded += (sender, args) => PlayShowAnimation(duration, 400);
            Closing += (sender, args) =>
            {
                if (!hideAnimationPlayed)
                {
                    args.Cancel = true;
                    PlayHideAnimation(duration);
                }
            };
        }

        private void PlayShowAnimation(TimeSpan duration, double targetWindowHeight)
        {
            messageScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

            var animation = new DoubleAnimation(0, targetWindowHeight, duration);
            animation.Completed += (sender, args) => messageScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            BeginAnimation(HeightProperty, animation);
            BeginAnimation(TopProperty, new DoubleAnimation(Top, Top - (targetWindowHeight / 2.0), duration));
        }

        private void PlayHideAnimation(TimeSpan duration)
        {
            if (!hideAnimationPlayed)
            {
                hideAnimationPlayed = true;
                messageScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

                var animation = new DoubleAnimation(Height, 0, duration);
                animation.Completed += (sender, args) => Close();

                BeginAnimation(HeightProperty, animation);
                BeginAnimation(TopProperty, new DoubleAnimation(Top, Top + (Height / 2.0), duration));
            }
        }

        private bool hideAnimationPlayed = false;
    }
}