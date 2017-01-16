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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PodrozWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Podroz podroz = new Podroz();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisableButtons()
        {
            podrozbutton.IsEnabled = false;
            dodaj.IsEnabled = false;
            usun.IsEnabled = false;
            powrot.IsEnabled = false;
        }

        private void EnableButtons()
        {
            podrozbutton.IsEnabled = true;
            dodaj.IsEnabled = true;
            usun.IsEnabled = true;
            powrot.IsEnabled = true;
        }

        private void Clear()
        {
            nazwastacji.Clear();
        }

        private void podroz_Click(object sender, RoutedEventArgs e)
        {
            GridPodroz.Visibility = Visibility.Visible;
            GridStacja.Visibility = Visibility.Hidden;
            DisableButtons();
        }

        private void dalej_Click(object sender, RoutedEventArgs e)
        {
            if(rodzajcombo.SelectedIndex == 0)
            {
                podroz = new Podroz();
            }
            else
            {
                podroz = new LastMinute();
            }
            GridPodroz.Visibility = Visibility.Hidden;            
            GridStacja.Visibility = Visibility.Visible;
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
            Clear();
            GridStacja.Visibility = Visibility.Visible;
        }

        private void dodajstacje_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(nazwastacji.Text) == false)
                {
                    if (oplatacombo.SelectedIndex == 0)
                    {
                        podroz.DodajStacje(nazwastacji.Text, true);
                    }
                    else
                    {
                        podroz.DodajStacje(nazwastacji.Text, false);
                    }
                    info.Text = podroz.ToString();
                    EnableButtons();
                }
                else
                {
                    MessageBox.Show("Nie podano nazwy stacji.");
                }
            }
            catch
            {
                MessageBox.Show("Nie podano nazwy stacji.");
            }
        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                podroz.UsunStacje();
            }
            catch
            {
                
            }
            info.Text = podroz.ToString();
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                podroz.Powrot();
            }
            catch
            {
                MessageBox.Show("Nie ma żadnych stacji.");
            }
            info.Text = podroz.ToString();
        }

        private void zapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                podroz.ZapiszPodroz();
                MessageBox.Show("Zapisano podróż!");
            }
            catch
            {
                MessageBox.Show("Nie udało się zapisać podróży.");
            }

        }

        
    }
}
