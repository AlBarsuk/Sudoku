
using System.Windows;


namespace MySudoku
{
    /// <summary>
    /// Логика взаимодействия для BestScores.xaml
    /// </summary>
    public partial class BestScores : Window
    {
        public BestScores()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
        }
    }
}
