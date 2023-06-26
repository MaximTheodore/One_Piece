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
    /// Логика взаимодействия для Page1_kassa.xaml
    /// </summary>
    public partial class Page1_kassa : Page
    {
        PrinterTableAdapter printer = new PrinterTableAdapter();
        PrinterTableAdapter printer1 = new PrinterTableAdapter();
        public Page1_kassa()
        {
            InitializeComponent();
            MainList.ItemsSource = printer.GetData();
            printer1 = null;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            /*Print__ print__ = new Print__();
            List<Print__> printList = new List<Print__>();
            DataRowView view = MainList.ItemsSource as DataRowView;
           print__.model =  view.Row[1].ToString();
            print__.speeed =  view.Row[2].ToString(); 
            print__.prices =  (float)view.Row[3];
           print__.colors =  (bool)view.Row[4];
            print__.a =  (int)view.Row[5]; print__.b = (int)view.Row[6]; 
            print__.c = (int)view.Row[7];
            print__.d= (int)view.Row[7];
           print__.e = (int)view.Row[8]; ;
            printList.Add(print__);
          
             OrderList.ItemsSource = printList;*/
         }
    }
}
