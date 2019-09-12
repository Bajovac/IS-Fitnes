using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Update29.xaml
    /// </summary>
    public partial class UpdateKuhinjaModal : Window
    {


        private string id;
        string ime;
        string prezime;
        string jmbg;
        string brk;

        public UpdateKuhinjaModal()
        {
            InitializeComponent();
        }

        List<KuhinjaData> lista = new List<KuhinjaData>();


        public UpdateKuhinjaModal(string id, string ime, string prezime, string jmbg, string brk)
        {

            InitializeComponent();

            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.brk = brk;

            boxID.Text = id;
            boxIME.Text = ime;
            boxPREZIME.Text = prezime;
            boxJMBG.Text = jmbg;
            boxBRK.Text = brk;
            UcitajDatotekuResursa();
        }



        // SERIJALIZACIJA/DESERIJALIZACIJA IZ DATOTEKE
        private readonly string _osoblje = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kuhinja.bin");


        private void UcitajDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            // TREBA IF ELSE, PROVERI DA LI RADI BEZ LISTA != NULL




            try
            {
                // obsCol ima ugradjen konstuktor samo ubacim listu u njega
                stream = File.Open(_osoblje, FileMode.OpenOrCreate);
                lista = (List<KuhinjaData>)formatter.Deserialize(stream);

                Console.WriteLine(lista);

                foreach (KuhinjaData item in lista)
                {
                    Console.WriteLine(item.Id);
                }

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



            foreach (KuhinjaData data29 in lista)
            {
                if (data29.Id == this.id)
                {
                    data29.Id = boxID.Text;
                    data29.Ime = boxIME.Text;
                    data29.Prezime = boxPREZIME.Text;
                    data29.Jmbg = boxJMBG.Text;
                    data29.Brk = boxBRK.Text;

                }
            }

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

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            MemorisiDatotekuResursa();
            UcitajDatotekuResursa();
            MainWindow pocetniProzor = Window.GetWindow(this) as MainWindow;
            if (pocetniProzor != null)
            {
                UcitajDatotekuResursa();
                pocetniProzor.kuhinja.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
                UcitajDatotekuResursa();
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            UcitajDatotekuResursa();
            MainWindow pocetniProzor = Window.GetWindow(this) as MainWindow;
            if (pocetniProzor != null)
            {
                UcitajDatotekuResursa();
                pocetniProzor.kuhinja.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
                UcitajDatotekuResursa();
            }
        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //omogucava da se prozor pomera tako sto se drzi levi klik na prozoru
        }

        //private void boxIP_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = Regex.IsMatch(e.Text, "[^0-9.a-Z- ]+");
        //}
    }
}
