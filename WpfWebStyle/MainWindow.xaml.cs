using System.Windows;

namespace WpfWebStyle
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Tracing.Enable();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
