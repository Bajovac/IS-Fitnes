﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Add26.xaml
    /// </summary>
    public partial class AddOsoblje : UserControl
    {
        List<OsobljeData> lista = new List<OsobljeData>();

        public AddOsoblje()
        {
            InitializeComponent();

            UcitajDatotekuResursa();
        }

        // SERIJALIZACIJA/DESERIJALIZACIJA IZ DATOTEKE
        private readonly string _osoblje = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "osoblje.bin");


        private void UcitajDatotekuResursa()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            // TREBA IF ELSE, PROVERI DA LI RADI BEZ LISTA != NULL




            try
            {
                // obsCol ima ugradjen konstuktor samo ubacim listu u njega
                stream = File.Open(_osoblje, FileMode.OpenOrCreate);
                lista = (List<OsobljeData>)formatter.Deserialize(stream);

                Console.WriteLine(lista);

                foreach (OsobljeData item in lista)
                {
                    Console.WriteLine(item.Ime);
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

            //Random number = new Random();

            OsobljeData data29 = new OsobljeData();
            data29.Id = boxID.Text;
            data29.Ime = boxIME.Text;
            data29.Prezime = boxPREZIME.Text;
            data29.Jmbg = boxJMBG.Text;
            data29.Brk = boxBRK.Text;

            lista.Add(data29);

            foreach (OsobljeData person in lista)
            {
                Console.WriteLine(person.Id);
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
                pocetniProzor.osoblje.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;


            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            UcitajDatotekuResursa();
            this.Visibility = Visibility.Collapsed;
            UcitajDatotekuResursa();
            MainWindow pocetniProzor = Window.GetWindow(this) as MainWindow;
            if (pocetniProzor != null)
            {
                UcitajDatotekuResursa();
                pocetniProzor.osoblje.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;

            }
        }
    }
}
