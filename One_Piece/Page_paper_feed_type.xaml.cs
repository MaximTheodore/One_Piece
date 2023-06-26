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
    /// Логика взаимодействия для Page_paper_feed_type.xaml
    /// </summary>
    public partial class Page_paper_feed_type : Page
    {
        paper_feed_typeTableAdapter paper_Feed_ = new paper_feed_typeTableAdapter();
        public Page_paper_feed_type()
        {
            InitializeComponent();
            Rol.ItemsSource = paper_Feed_.GetData();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        { if (Role.Text != null)
            {
                paper_Feed_.InsertQueryfeed(Role.Text);
                Rol.ItemsSource = paper_Feed_.GetData();
            } else
            {
                Role.Text = null;
                MessageBox.Show("Ничего не введено");
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        { object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (Role.Text != null && id != null)
            { paper_Feed_.UpdateQueryFeed(Role.Text,Convert.ToInt32(id));
              Rol.ItemsSource = paper_Feed_.GetData();
            } else
            { Role.Text = null;
              MessageBox.Show("Ничего не введено");
            }

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (id != null)
            { paper_Feed_.DeleteQueryfeed(Convert.ToInt32(id));
              Rol.ItemsSource = paper_Feed_.GetData();
            } else MessageBox.Show("ничего не выбрано");
        }
        private void Rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = Rol.SelectedItem as DataRowView;
            if (view != null)
            { Role.Text = view.Row[1].ToString();
            }
        }
    }
}
