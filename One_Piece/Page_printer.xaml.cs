using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Логика взаимодействия для Page_printer.xaml
    /// </summary>
    public partial class Page_printer : Page
    {
        PrinterTableAdapter printer = new PrinterTableAdapter();
        producerTableAdapter adapter = new producerTableAdapter();
        type_printerTableAdapter type = new type_printerTableAdapter();
        paper_feed_typeTableAdapter paper = new paper_feed_typeTableAdapter();
        printer_brandTableAdapter brand = new printer_brandTableAdapter();
        factoryTableAdapter factory = new factoryTableAdapter();
        public Page_printer()
        {
            InitializeComponent();
            Rol.ItemsSource = printer.GetData();
            Com_producer.ItemsSource = adapter.GetData();
            Com_type.ItemsSource = type.GetData();
            Com_feed.ItemsSource = paper.GetData();
            Com_brand.ItemsSource = brand.GetData();
            Com_factory.ItemsSource = factory.GetData();

            Com_producer.SelectedValuePath = "id_producer";
            Com_producer.DisplayMemberPath = "Name_producer";

            Com_type.SelectedValuePath = "id_type_printer";
            Com_type.DisplayMemberPath = "name_type_printer";

            Com_feed.SelectedValuePath = "id_paper_feed_type";
            Com_feed.DisplayMemberPath = "name_paper_feed_type";

            Com_brand.SelectedValuePath = "id_printer_brand";
            Com_brand.DisplayMemberPath = "Name_printer_brand";

            Com_factory.SelectedValuePath = "id_factory";
            Com_factory.DisplayMemberPath = "Name_factory";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                double a = Convert.ToDouble(prices.Text);
                if (Convert.ToDouble(prices.Text) >= 0 && model.Text != null && speed.Text != null)
                {
                    printer.InsertQueryPrinter(model.Text, speed.Text, (float)a, Color.IsChecked,
                    Convert.ToInt32(Com_producer.SelectedValue), Convert.ToInt32(Com_type.SelectedValue), Convert.ToInt32(Com_feed.SelectedValue),
                    Convert.ToInt32(Com_brand.SelectedValue), Convert.ToInt32(Com_factory.SelectedValue));

                    Rol.ItemsSource = printer.GetData();
                }
                else
                {
                    MessageBox.Show("Число меньше нуля");
                }
            }
            catch { MessageBox.Show("Вы ввели буквы, введите цифры"); }

            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
                object id = (Rol.SelectedItem as DataRowView).Row[0];

            try
            {
                double a = Convert.ToDouble(prices.Text);
            if (Convert.ToDouble(prices.Text) >= 0 && id!=null && model.Text != null && speed.Text != null)
            {
                printer.UpdateQueryPrinter(model.Text, speed.Text, (float)a, Color.IsChecked,
                Convert.ToInt32(Com_producer.SelectedValue), Convert.ToInt32(Com_type.SelectedValue), Convert.ToInt32(Com_feed.SelectedValue),
                Convert.ToInt32(Com_brand.SelectedValue), Convert.ToInt32(Com_factory.SelectedValue), Convert.ToInt32(id));
                Rol.ItemsSource = printer.GetData();

            }
            else
            {
                MessageBox.Show("Число меньше нуля");
            }
            }
            catch { MessageBox.Show("Вы ввели буквы, введите цифры"); }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if(id != null)
            {
                printer.DeleteQuerPrinter(Convert.ToInt32(id));
                Rol.ItemsSource = printer.GetData();

            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для удаления");
            }
        }

        private void Rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = Rol.SelectedItem as DataRowView;
            model.Text = view.Row[1].ToString() ;
                speed.Text = view.Row[2].ToString(); 
                prices.Text = view.Row[3].ToString();
            Color.IsChecked = (bool)view.Row[4];
            var info1 = view.Row["id_producer"] as int?;
            var info2 = view.Row["id_type_printer"] as int?;
            var info3 = view.Row["id_paper_feed_type"] as int?;
            var info4 = view.Row["id_printer_brand"] as int?;
            var info5 = view.Row["id_factory"] as int?;
            if(info1 != null &&  info2 != null && info3 != null &&  info4 != null)
            {
                Com_producer.SelectedValue = info1;
                Com_type.SelectedValue = info2;
                Com_feed.SelectedValue = info3;
                Com_brand.SelectedValue = info4;
                Com_factory.SelectedValue = info5;
                    
             }

        }
    }
}
