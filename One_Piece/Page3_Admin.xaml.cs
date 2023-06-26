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
    /// Логика взаимодействия для Page3_Admin.xaml
    /// </summary>
    public partial class Page3_Admin : Page
    {
        LoginDataTableAdapter loginData = new LoginDataTableAdapter();
        PostTableAdapter adapter = new PostTableAdapter();  
        public Page3_Admin()
        {
            InitializeComponent();
            Rol.ItemsSource = loginData.GetData();
            Combo.ItemsSource = adapter.GetData();
            Combo.DisplayMemberPath = "_name";
            Combo.SelectedValuePath = "id_post";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Lo.Text != null && Pas.Text != null && Convert.ToInt32(Combo.SelectedValue) != null)
            {
                loginData.InsertQueryLogPas(Lo.Text, Pas.Text, Convert.ToInt32(Combo.SelectedValue));
                Rol.ItemsSource = loginData.GetData();
            }
            else MessageBox.Show("Что-то не введено");
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (Lo.Text != null && Pas.Text != null && Convert.ToInt32(Combo.SelectedValue) != null && id != null)
            { loginData.UpdateQueryLogPass(Lo.Text, Pas.Text, Convert.ToInt32(Combo.SelectedValue), Convert.ToInt32(id));
              Rol.ItemsSource = loginData.GetData(); }
            else MessageBox.Show("Что-то не введено или не выбрано");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (id!=null) {  loginData.DeleteQueryLogPass(Convert.ToInt32(id));
                Rol.ItemsSource = loginData.GetData();
            } else
            {  MessageBox.Show("Вы ничего не выбрали"); }
        }
        private void Rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = Rol.SelectedItem as DataRowView;
            Lo.Text = view.Row[1].ToString();
            Pas.Text = view.Row[2].ToString();
            var info = view.Row["id_post"] as int?;
            if (info != null)
            {Combo.SelectedValue = info;}
        }
    }
}
