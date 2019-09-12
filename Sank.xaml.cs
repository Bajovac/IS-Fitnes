using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Osoblje.xaml
    /// </summary>
    public partial class Sank : UserControl
    {
        List<SankData> lista = new List<SankData>();

        public Sank()
        {
            InitializeComponent();



            UcitajDatotekuResursa();

        }

        // SERIJALIZACIJA/DESERIJALIZACIJA IZ DATOTEKE
        private readonly string _osoblje = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sank.bin");


        public void UcitajDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {

                stream = File.Open(_osoblje, FileMode.OpenOrCreate);
                lista = null;
                lista = (List<SankData>)formatter.Deserialize(stream);

                this.DataGridPeople.ItemsSource = lista;


            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }


        }


        private void MemorisiDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {

                //lista ima ugradjen konstuktor za obsCol

                stream = File.Open(_osoblje, FileMode.OpenOrCreate);
                formatter.Serialize(stream, lista);
            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

            MainWindow pocetniProzor = Window.GetWindow(this) as MainWindow;
            if (pocetniProzor != null)
            {
                pocetniProzor.AddSank.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
                UcitajDatotekuResursa();
            }


            UcitajDatotekuResursa();

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {


            UpdateSankModal update29Modal = new UpdateSankModal(
               lista[DataGridPeople.SelectedIndex].Id,
                lista[DataGridPeople.SelectedIndex].Ime,
                lista[DataGridPeople.SelectedIndex].Prezime,
                lista[DataGridPeople.SelectedIndex].Jmbg,
                lista[DataGridPeople.SelectedIndex].Brk);



            UcitajDatotekuResursa();
            update29Modal.Show();


            UcitajDatotekuResursa();



        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

            lista.RemoveAt(DataGridPeople.SelectedIndex);

            MemorisiDatotekuResursa();

            UcitajDatotekuResursa();


        }
    }
}
