using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void oSoftveru(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autor: Stefan Vidović\nVerzija: 1.0.1", "O Softveru");
        }

        private void uIzradiKlik(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ovaj prozor je trenutno u izradi", "U izradi", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void osobljeKlik(object sender, RoutedEventArgs e)
        {
            osoblje.UcitajDatotekuResursa();
            osoblje.Visibility = Visibility.Visible;
            recepcija.Visibility = Visibility.Collapsed;
            kuhinja.Visibility = Visibility.Collapsed;
            sank.Visibility = Visibility.Collapsed;

        }
        private void sankKlik(object sender, RoutedEventArgs e)
        {
            sank.UcitajDatotekuResursa();
            sank.Visibility = Visibility.Visible;
            recepcija.Visibility = Visibility.Collapsed;
            osoblje.Visibility = Visibility.Collapsed;
            kuhinja.Visibility = Visibility.Collapsed;
        }
        private void kuhinjaKlik(object sender, RoutedEventArgs e)
        {
            kuhinja.UcitajDatotekuResursa();
            kuhinja.Visibility = Visibility.Visible;
            recepcija.Visibility = Visibility.Collapsed;
            osoblje.Visibility = Visibility.Collapsed;
            sank.Visibility = Visibility.Collapsed;

        }
        private void recepcijaKlik(object sender, RoutedEventArgs e)
        {
            recepcija.UcitajDatotekuResursa();
            recepcija.Visibility = Visibility.Visible;
            osoblje.Visibility = Visibility.Collapsed;
            kuhinja.Visibility = Visibility.Collapsed;
            sank.Visibility = Visibility.Collapsed;

        }
        /*
private static void OnValueChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
{
   if (!(d is Window))
   {
       return;
   }
   var window = d as Window;
   if ((bool)e.NewValue)
   {
       InputBinding escapeBinding = new InputBinding(AppCommands.WindowCloseCommand, new KeyGesture(Key.Escape));
       escapeBinding.CommandParameter = window;
       window.InputBindings.Add(escapeBinding);
       window.Closing += Window_Closing;
   }
   else
   {
       window.Closing -= Window_Closing;
   }
}

static void Window_Closing(object sender, CancelEventArgs e)
{


e.Cancel = MessageBox.Show(window, "Are you sure?", "Exit",
MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes;

}
*/
    }
}
