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
    /// Логика взаимодействия для Page_producer.xaml
    /// </summary>
    public partial class Page_producer : Page
    {
        producerTableAdapter  producer = new producerTableAdapter();
        public Page_producer()
        {
            InitializeComponent();
            Rol.ItemsSource = producer.GetData();
           /* List<Producerr> list = new List<Producerr>() { new Producerr("kol"), new Producerr("Hop"), new Producerr("Joop") };
            Ser_deser.Ser(list, "Producer.json");*/
           /* List<Fact> facts = new List<Fact>() { new Fact("YUgggg","Москва ул Печатников 3"), new Fact("Hope", "Москва ул Живота 13"), new Fact("Sope", "Москва ул Волков 3"), new Fact("Lope", "Москва ул Продажи 23"), new Fact("Koll", "Москва ул Печатников 3") };
            Ser_deser.Ser(facts, "Fabrica.json");*/
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Role.Text != null)
            {
                producer.InsertQueryProducer(Role.Text);
                Rol.ItemsSource = producer.GetData();
            }
            else
            { Role.Text = null; MessageBox.Show("Ничего не введено"); }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (Role.Text != null && id != null)
            {
                producer.UpdateQueryProducer(Role.Text, Convert.ToInt32(id));
                Rol.ItemsSource = producer.GetData();
            } else
            { Role.Text = null;
                MessageBox.Show("Ничего не введено");
            }
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            object id = (Rol.SelectedItem as DataRowView).Row[0];
            if (id != null)
            {  producer.DeleteQueryProducer(Convert.ToInt32(id));
                Rol.ItemsSource = producer.GetData();
            } else MessageBox.Show("ничего не выбрано");
        }
        private void Rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView view = Rol.SelectedItem as DataRowView;
            if (view != null)
            {  Role.Text = view.Row[1].ToString();}
        }
        private void Impo_Click(object sender, RoutedEventArgs e)
        { List<Producerr> list = Ser_deser.Des<List<Producerr>>("Producer.json");
            foreach(var item in list)
            { producer.InsertQueryProducer(item.name);}
            Rol.ItemsSource = null;
            Rol.ItemsSource = producer.GetData();
        }
    }
}
