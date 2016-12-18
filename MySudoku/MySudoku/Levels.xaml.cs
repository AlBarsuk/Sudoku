using System;
using System.Windows;
using System.Windows.Controls;

namespace MySudoku
{
    /// <summary>
    /// Логика взаимодействия для Levels.xaml
    /// </summary>
    public partial class Levels : Window
    {
        
        Generator g = new Generator();
        int n = 0;
        public int?[][] current = new int?[9][];
        public Levels()
        {
            InitializeComponent();
            
            g.mass = g.Create();
            var mass = g.mass;
            var k = mass;

            EndButton.IsEnabled = false;
        } 
        
        private void Show_cells(int?[][] massiv)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    string cellname = "textBox_" + i + j;
                    TextBox a = (TextBox)grid.FindName(cellname);

                    a.Text = "" + massiv[j][i];
                    if (massiv[j][i] != 0)
                    {
                        a.IsReadOnly = true;
                    }
                    else
                    {
                        a.Text = "";
                    }
                }
            }
        }

       

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            current = g.mass;
            g.Easy(current);
            Show_cells(current);
            EndButton.IsEnabled = true;
            
            checkBox2.IsEnabled = false;
            checkBox1.IsEnabled = false;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            current = g.mass;
            g.Medium(current);
            Show_cells(current);

            EndButton.IsEnabled = true;
            checkBox2.IsEnabled = false;
            checkBox.IsEnabled = false;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            current = g.mass;
            g.Hard(current);
            Show_cells(current);

            EndButton.IsEnabled = true;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            n++;
            int c = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    string cellname = "textBox_" + i + j;
                    TextBox a = (TextBox)grid.FindName(cellname);
                    int s;
                    if (!int.TryParse(a.Text, out s))
                    {
                        s = 20;
                    }
                    else
                    {
                         s = Convert.ToInt32(a.Text);
                    }
                    if (s != g.mass[j][i])
                    {
                        a.Clear();
                        c++; 
                    }

               }
                label1.Content = "Количество проверок: " + n;
                label2.Content = "Количество ошибок: " + c;
                
            }
            if (c == 0)
            {
                button1.IsEnabled = true;
            }
            
            
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваш результат успешно сохрaнен!");
            this.Close();
            Application.Current.MainWindow.Show();
        }
    }
}
