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
using One_Piece.PRINTER_SHOP_DataSetTableAdapters;
namespace One_Piece
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginDataTableAdapter login = new LoginDataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = login.GetData().Rows;
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString()== Log.Text && 
                    allLogins[i][2].ToString()== Pas.Password) 
                {
                    int roleid = (int)allLogins[i][3];
                    switch (roleid)
                    {
                        case 1:
                            AdminIcon icon = new AdminIcon();
                            icon.Show();
                            break;
                        case 2:
                            Sklad icons = new Sklad();
                            icons.Show();
                            break;
                        case 3:
                            Kassa iconss = new Kassa();
                            iconss.Show();
                            break;
                    }
                    this.Close();
                }
               /* else
                {
                    MessageBox.Show("Не тот пароль(");
                    break;

                }*/
            }

        }
    }
}
