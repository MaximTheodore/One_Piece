using One_Piece.PRINTER_SHOP_DataSetTableAdapters;
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

namespace One_Piece
{
    /// <summary>
    /// Логика взаимодействия для Page0_Admin.xaml
    /// </summary>
    public partial class Page0_Admin : Page
    {
        PostTableAdapter post = new PostTableAdapter();
        public Page0_Admin()
        {
            InitializeComponent();
            Rol.ItemsSource = post.GetData();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Role.Text != null)
            {
                post.InsertQueryPost(Role.Text);
                Rol.ItemsSource = post.GetData();
            }
            else MessageBox.Show("Строка пуста");
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (Role.Text != null && id != null)
            {post.UpdateQueryPost(Role.Text, Convert.ToInt32(id));
             Rol.ItemsSource = post.GetData();}
            else MessageBox.Show("Строка пуста");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (id != null)
            {
                post.DeleteQueryPost(Convert.ToInt32(id));
                Rol.ItemsSource = post.GetData();

            }
            else MessageBox.Show("пусто");

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
