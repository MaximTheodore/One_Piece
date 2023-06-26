using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Page_printer_brand.xaml
    /// </summary>
    public partial class Page_printer_brand : Page
    {
        printer_brandTableAdapter printer_Brand = new printer_brandTableAdapter();
        public Page_printer_brand()
        {
            InitializeComponent();
            Rol.ItemsSource = printer_Brand.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Role.Text != null)
            {
                printer_Brand.InsertQuerybrand(Role.Text);
                Rol.ItemsSource = printer_Brand.GetData();
            }
            else { Role.Text = null;MessageBox.Show("Ничего не введено");  }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        { object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (Role.Text != null && id != null)
            {printer_Brand.UpdateQueryBrand(Role.Text, Convert.ToInt32(id));
             Rol.ItemsSource = printer_Brand.GetData();
            } else
            { Role.Text = null;
              MessageBox.Show("Ничего не введено"); }
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (id != null)
            { printer_Brand.DeleteQueryBrand(Convert.ToInt32(id));
               Rol.ItemsSource = printer_Brand.GetData();

            }
            else MessageBox.Show("ничего не выбрано");
        }

        private void Rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = Rol.SelectedItem as DataRowView;
            if (view != null)
            {
                Role.Text = view.Row[1].ToString();
            }
        }
    }
}
