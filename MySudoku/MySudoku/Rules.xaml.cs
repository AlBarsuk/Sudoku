
using System.Windows;


namespace MySudoku
{
    /// <summary>
    /// Логика взаимодействия для Rules.xaml
    /// </summary>
    public partial class Rules : Window
    {
        public Rules()
        {
            InitializeComponent();
            Application.Current.MainWindow.Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            Application.Current.MainWindow.Show();
           
        }
    }
}
