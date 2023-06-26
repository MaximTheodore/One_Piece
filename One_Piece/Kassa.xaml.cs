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
using System.Windows.Shapes;

namespace One_Piece
{
    /// <summary>
    /// Логика взаимодействия для Kassa.xaml
    /// </summary>
    public partial class Kassa : Window
    {
        public Kassa()
        {
            InitializeComponent();
            Page.Content = new Page1_kassa();
        }

        private void Leftbtn_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page1_kassa();
        }

        private void Rightbtn2_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page2_kassa();
        }
    }
}
