using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace uwp_fancy_xaml_panel.UserControls
{
    public sealed partial class FancyPanel : UserControl
    {
        public event EventHandler BackdropTapped;

        public FancyPanel()
        {
            InitializeComponent();
        }

        private void Backdrop_Tapped(object sender, TappedRoutedEventArgs e) => BackdropTapped?.Invoke(this, new EventArgs());

        public static readonly DependencyProperty PanelContentProperty = DependencyProperty.Register(
            "PanelContent", typeof(FrameworkElement), typeof(FancyPanel), new PropertyMetadata(default(FrameworkElement), OnPanelContentChanged));

        private static void OnPanelContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FancyPanel instance)
            {
                instance.Presenter.Content = e.NewValue;
            }
        }

        public FrameworkElement PanelContent
        {
            get => (FrameworkElement) GetValue(PanelContentProperty);
            set => SetValue(PanelContentProperty, value);
        }
    }
}
