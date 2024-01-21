using System.Windows;
using System.Windows.Controls;

namespace MainTool.Views
{
    public class RowDefinitionHiddenable : RowDefinition
    {
        public static DependencyProperty IsVisibleProperty;

        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        static RowDefinitionHiddenable()
        {
            IsVisibleProperty = DependencyProperty.Register("IsVisible",
                typeof(bool),
                typeof(RowDefinitionHiddenable),
                new PropertyMetadata(true, new PropertyChangedCallback(OnIsVisibleChanged)));

            HeightProperty.OverrideMetadata(typeof(RowDefinitionHiddenable),
                new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null,
                    new CoerceValueCallback(CoerceWidth)));

            MinHeightProperty.OverrideMetadata(typeof(RowDefinitionHiddenable),
                new FrameworkPropertyMetadata((double)0, null,
                    new CoerceValueCallback(CoerceMinWidth)));
        }

        public static void SetIsVisible(DependencyObject obj, bool nIsVisible)
        {
            obj.SetValue(IsVisibleProperty, nIsVisible);
        }

        public static bool GetIsVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsVisibleProperty);
        }

        private static void OnIsVisibleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            obj.CoerceValue(HeightProperty);
            obj.CoerceValue(MinHeightProperty);
        }

        private static object CoerceWidth(DependencyObject obj, object nValue)
        {
            return ((RowDefinitionHiddenable)obj).IsVisible ? nValue : new GridLength(0);
        }

        private static object CoerceMinWidth(DependencyObject obj, object nValue)
        {
            return ((RowDefinitionHiddenable)obj).IsVisible ? nValue : (double)0;
        }
    }
}