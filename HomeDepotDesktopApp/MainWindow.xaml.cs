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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var address = Address.Text;
            var email = Email.Text;
            var username = Username.Text;
            var password = Password.Text;
            var id = _context.Customers.Count() == 0 ? 0 : _context.Customers.Max(x => x.Id) + 1;
            if (String.IsNullOrWhiteSpace(username))
            {
                // no login
                _context.Customers.Add(new Customer(id, name, address));
                _context.SaveChanges();
            } else
            {
                // with login
                _context.Customers.Add(new CustomerWithLogin(id, name, address, username, password));
                _context.SaveChanges();
            }
        }
    }
}
