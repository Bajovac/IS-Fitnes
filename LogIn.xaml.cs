using System;
using System.Collections.Generic;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        public void LogIn_Click(object sender, RoutedEventArgs e)
        {

            if (UsernameBox.Text == Projekat.Properties.Resources.UsernameA && PasswordBox.Password == Projekat.Properties.Resources.PasswordA) //ovo bas i nije najsigurniji nacin da se cuva passworda al ajd sad
            {
                this.Hide();
                MainWindow test = new MainWindow();
                test.ShowDialog();
            }
            else
            {
                if (UsernameBox.Text == Projekat.Properties.Resources.UsernameU && PasswordBox.Password == Projekat.Properties.Resources.PasswordU)
                {
                    MessageBox.Show("Korisnik postoji u sistemu, ali njegov interfejs nije još gotov!");


                }


                else
                {
                    if ((UsernameBox.Text != Projekat.Properties.Resources.UsernameA || UsernameBox.Text != Projekat.Properties.Resources.UsernameU)
                        &&
                       (PasswordBox.Password != Projekat.Properties.Resources.PasswordA || PasswordBox.Password != Projekat.Properties.Resources.PasswordU))

                        MessageBox.Show("Unesite ponovo vaše korisničko ime i lozinku");


                }
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Test for Enter key.
            if (e.Key == Key.Enter)
            {
                
                if (UsernameBox.Text == Projekat.Properties.Resources.UsernameA && PasswordBox.Password == Projekat.Properties.Resources.PasswordA) //ovo bas i nije najsigurniji nacin da se cuva passworda al ajd sad
                {
                    this.Hide();
                    MainWindow test = new MainWindow();
                    test.ShowDialog();
                }
                else
                {
                    if (UsernameBox.Text == Projekat.Properties.Resources.UsernameU && PasswordBox.Password == Projekat.Properties.Resources.PasswordU)
                    {
                        MessageBox.Show("Korisnik postoji u sistemu, ali njegov interfejs nije još gotov!");


                    }


                    else
                    {
                        if ((UsernameBox.Text != Projekat.Properties.Resources.UsernameA || UsernameBox.Text != Projekat.Properties.Resources.UsernameU)
                            &&
                           (PasswordBox.Password != Projekat.Properties.Resources.PasswordA || PasswordBox.Password != Projekat.Properties.Resources.PasswordU))

                            MessageBox.Show("Unesite ponovo vaše korisničko ime i lozinku");


                    }
                }


            }
        }
    }
}
