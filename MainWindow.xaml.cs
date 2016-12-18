using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySudoku
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Levels level = new Levels();
            level.Show();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            Rules rule = new Rules();
            rule.Show();
        }

        private void Score_Click(object sender, RoutedEventArgs e)
        {
            BestScores score = new BestScores();
            score.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            info.Show();
        }
    }
}
