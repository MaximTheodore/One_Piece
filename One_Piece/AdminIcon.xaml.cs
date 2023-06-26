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
using One_Piece.PRINTER_SHOP_DataSetTableAdapters;
namespace One_Piece
{
    /// <summary>
    /// Логика взаимодействия для AdminIcon.xaml
    /// </summary>
    public partial class AdminIcon : Window
    {
        
        public AdminIcon()
        {
            InitializeComponent();
            Page1.Content = new Page0_Admin();
        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            Page1.Content = new Page0_Admin();
        }

        private void Inform_Click(object sender, RoutedEventArgs e)
        {
            Page1.Content = new Page3_Admin();
        }

        private void Passwords_Click(object sender, RoutedEventArgs e)
        {
            Page1.Content = new Page2_Admin();
        }
    }
}
