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
    /// Логика взаимодействия для Page2_Admin.xaml
    /// </summary>
    public partial class Page2_Admin : Page
    {


        InfomationTableAdapter infomationTable = new InfomationTableAdapter();
        LoginDataTableAdapter postTableAdapter = new LoginDataTableAdapter();
        public Page2_Admin()
        {
            InitializeComponent();
            Rol.ItemsSource = infomationTable.GetData();
            Com.ItemsSource = postTableAdapter.GetData();
            Com.SelectedValuePath = "id";
            Com.DisplayMemberPath = "Login_";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Sur.Text != null && Nam.Text != null && Las.Text != null && Convert.ToInt32(Com.SelectedValue) != null)
            { infomationTable.InsertQueryInfo(Sur.Text, Nam.Text, Las.Text, Convert.ToInt32(Com.SelectedValue));
                Rol.ItemsSource = infomationTable.GetData();
            }else { MessageBox.Show("Вы что-то забыли ввести");}
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        { object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (Sur.Text != null && Nam.Text != null && Las.Text != null && Convert.ToInt32(Com.SelectedValue) != null && id != null)
            {
                infomationTable.UpdateQueryInfo(Sur.Text, Nam.Text, Las.Text, Convert.ToInt32(Com.SelectedValue), Convert.ToInt32(id));
                Rol.ItemsSource = infomationTable.GetData();
            } else { MessageBox.Show("Вы что-то забыли ввести");}
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (id != null)
            {
                infomationTable.DeleteQueryInfo(Convert.ToInt32(id));
                Rol.ItemsSource = infomationTable.GetData();
            } else { MessageBox.Show("Вы ничего не выбрали"); }
        }
        private void Rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = Rol.SelectedItem as DataRowView;
            Sur.Text = view.Row[1].ToString();
            Nam.Text = view.Row[2].ToString();
            Las.Text = view.Row[3].ToString();
            var info = view["id"] as int?;
            if (info != null) {
                Com.SelectedValue = info; 
            }
        }
    }
}
