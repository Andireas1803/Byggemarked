using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
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

namespace HomeDepotDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HomeDepotContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new HomeDepotContext();
        }

        private void ClearCustomerFields()
        {
            Name.Clear();
            Address.Clear();
            Email.Clear();
            Username.Clear();
            Password.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var address = Address.Text;
            var email = Email.Text;
            var username = Username.Text;
            var password = Password.Text;
            if (String.IsNullOrWhiteSpace(Id.Text))
            {
                var id = _context.Customers.Count() == 0 ? 0 : _context.Customers.Max(x => x.Id) + 1;
                if (String.IsNullOrWhiteSpace(username))
                {
                    // no login
                    _context.Customers.Add(new Customer(id, name, address, email));
                    _context.SaveChanges();
                    MessageBox.Show("Kunde blevet tilføjet", "Tilføjet", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // with login
                    _context.Customers.Add(new CustomerWithLogin(id, name, address, email, username, password));
                    _context.SaveChanges();
                    MessageBox.Show("Kunde med login blevet tilføjet", "Tilføjet", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ClearCustomerFields();
            } else
            {
                var id = Convert.ToInt32(Id.Text);
                var customers = _context.Customers.Where(w => w.Id == id).ToList();
                if(customers.Count() > 0) {
                    var c = customers[0];
                    c.Name = name;
                    c.Address = address;
                    c.Email = email;
                    if(c is CustomerWithLogin)
                    {
                        var cwl = c as CustomerWithLogin;
                        cwl.Username = username;
                        cwl.Password = password;
                    }
                    MessageBox.Show("Kunden er blevet ændret", "Ændret", MessageBoxButton.OK, MessageBoxImage.Information);
                    _context.SaveChanges();
                }
            }
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Id.Text))
            {
                var id = Convert.ToInt32(Id.Text);
                var c = _context.Customers.Where(w => w.Id == id).ToList();
                if (c.Count > 0)
                {
                    Name.Text = c[0].Name;
                    Address.Text = c[0].Address;
                    Email.Text = c[0].Email;
                    if (c[0] is CustomerWithLogin)
                    {
                        var cwl = c[0] as CustomerWithLogin;
                        Username.Text = cwl.Username;
                        Password.Text = cwl.Password;
                    } else
                    {
                        Username.Clear();
                        Password.Clear();
                    }
                    BtnCreate.Content = "Rediger";
                    //Bookings.ItemsSource = _context.Bookings.Where(w => w.Customer.Id == id);
                } else
                {

                    MessageBox.Show("Der er ingen kunde med det ID", "Ikke fundet", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                ClearCustomerFields();
                BtnCreate.Content = "Opret";
            }
        }
    }
}
