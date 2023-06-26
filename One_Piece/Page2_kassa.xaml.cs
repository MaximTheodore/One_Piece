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
    /// Логика взаимодействия для Page2_kassa.xaml
    /// </summary>
    public partial class Page2_kassa : Page
    {
        Order_TableAdapter order_Table = new Order_TableAdapter() ;
        PRINTER_orderTableAdapter pRINTER_Order = new PRINTER_orderTableAdapter() ;
        InfomationTableAdapter infomationTableAdapter = new InfomationTableAdapter() ;
        PrinterTableAdapter printerTableAdapter = new PrinterTableAdapter() ;

        public Page2_kassa()
        {
            InitializeComponent();
            MainList.ItemsSource = order_Table.GetData();
            MainList1.ItemsSource = pRINTER_Order.GetData();
            Com_staff.ItemsSource = infomationTableAdapter.GetData();
            Com_staff.SelectedValuePath = "id_";
            Com_staff.DisplayMemberPath = "Name_";

            Com_printer.ItemsSource = printerTableAdapter.GetData();
            Com_printer.SelectedValuePath = "Printer_id";
            Com_printer.DisplayMemberPath = "MODEL";

            Com_order.ItemsSource = order_Table.GetData();
            Com_order.SelectedValuePath = "id_Order_";
            Com_order.DisplayMemberPath = "id_Order_";
        
        }
        private void Add1_Click(object sender, RoutedEventArgs e)
        {
            if (Pay.Text != null)
            {
                order_Table.InsertQueryOrder(Pay.Text, Convert.ToInt32(Com_staff.SelectedValue));
                MainList.ItemsSource = order_Table.GetData();
            }
            else { Pay.Text = null; MessageBox.Show("Ничего не введено"); }


        }

        private void Update1_Click(object sender, RoutedEventArgs e)
        {
            object id = (MainList.SelectedItem as DataRowView).Row[0];
            if (Pay.Text != null && id != null)
            {
                order_Table.UpdateQueryOrd(Pay.Text, Convert.ToInt32(Com_staff.SelectedValue), Convert.ToInt32(id));
                MainList.ItemsSource = order_Table.GetData();
            }
            {
                Pay.Text = null;
                MessageBox.Show("Ничего не введено");
            }
        }

        private void Delete1_Click(object sender, RoutedEventArgs e)
        {
            object id = (MainList.SelectedItem as DataRowView).Row[0];
            if (id != null)
            {
                order_Table.DeleteQueryPriOrd(Convert.ToInt32(id));
                MainList.ItemsSource = order_Table.GetData();
            }
            else MessageBox.Show("ничего не выбрано");
        }

        private void MainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = MainList.SelectedItem as DataRowView;    
            Pay.Text = view.Row[1].ToString();
            var info1 = view.Row["id_"] as int?;
            if (info1 != null)
            {
                Com_staff.SelectedValue = info1;
            }
        }

        private void Add2_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                pRINTER_Order.InsertQueryPriOrd(Convert.ToInt32(Com_printer.SelectedValue), Convert.ToInt32(Com_order.SelectedValue));
                MainList1.ItemsSource = pRINTER_Order.GetData();
            }
           
        }

        private void Update2_Click(object sender, RoutedEventArgs e)
        {
            object id = (MainList1.SelectedItem as DataRowView).Row[0];
            if (id != null)
            {
                pRINTER_Order.UpdateQueryPriOrd(Convert.ToInt32(Com_printer.SelectedValue), Convert.ToInt32(Com_order.SelectedValue), Convert.ToInt32(id));
                MainList1.ItemsSource = pRINTER_Order.GetData();
            }
            else MessageBox.Show("ничего не выбрано");

        }

        private void Delete2_Click(object sender, RoutedEventArgs e)
        {
            object id = (MainList1.SelectedItem as DataRowView).Row[0];
            if (id != null)
            {
                pRINTER_Order.DeleteQueryPriOrd(Convert.ToInt32(id));
                MainList1.ItemsSource = pRINTER_Order.GetData();
            }
            else MessageBox.Show("ничего не выбрано");

        }

        private void MainList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = MainList1.SelectedItem as DataRowView;
            var info1 = view.Row["Printer_id"] as int?;
            var info2 = view.Row["id_Order_"] as int?;
            if(info1 != null && info2 != null)
            {
                Com_printer.SelectedValue = info1;
                Com_order.SelectedValue = info2;
            }

        }
    }
}
