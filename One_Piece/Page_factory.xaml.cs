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
    /// Логика взаимодействия для Page_factory.xaml
    /// </summary>
    public partial class Page_factory : Page
    {
        factoryTableAdapter factory = new factoryTableAdapter();
        public Page_factory()
        {
            InitializeComponent();
            Rol.ItemsSource = factory.GetData();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        { if (Role.Text != null && Roles.Text!=null)
            {
                factory.InsertQueryFactory(Role.Text,Roles.Text);
                Rol.ItemsSource = factory.GetData();
            } else
            {  Role.Text = null;
                MessageBox.Show("Ничего не введено");
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (Role.Text != null && Roles.Text != null && id != null)
            { factory.UpdateQueryFactory(Role.Text, Roles.Text, Convert.ToInt32(id));
               Rol.ItemsSource = factory.GetData();
            }
            else
            { Role.Text = null;
                Roles.Text = null;
                MessageBox.Show("Ничего не введено");
            }
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (id != null)
            { factory.DeleteQueryFactory(Convert.ToInt32(id));
                Rol.ItemsSource = factory.GetData();
            } else MessageBox.Show("ничего не выбрано");
        }
        private void Rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  DataRowView view = Rol.SelectedItem as DataRowView;
            if (view != null)
            { Role.Text = view.Row[1].ToString();
              Roles.Text = view.Row[2].ToString();
            }
        }
        private void Impo_Click(object sender, RoutedEventArgs e)
        {
            List<Fact> facts = Ser_deser.Des<List<Fact>>("Fabrica.json");
            foreach (var item in facts)
            { factory.InsertQueryFactory(item.name,item.adress);}
            Rol.ItemsSource = null;
            Rol.ItemsSource = factory.GetData();

        }
    }
}
