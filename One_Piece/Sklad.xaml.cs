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
    /// Логика взаимодействия для Sklad.xaml
    /// </summary>
    public partial class Sklad : Window
    {
        public Sklad()
        {
            InitializeComponent();
            Page.Content = new Page_producer();

        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page_producer();   
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page_factory();
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page_paper_feed_type();
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page_printer_brand();
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page_type_printer();
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Page_printer();
        }
    }
}
