using ProviderSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProviderSystem.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Page
    {
        public MyAccount(User user)
        {
            var context = new ProviderDbContext();
            InitializeComponent();
            NameLabel.Content = user.Fio;
            EmailLabel.Content = user.Email;
            CityLabel.Content = context.Cities.FirstOrDefault(c => c.IdCity == user.IdCity).Name;
            AddressLabel.Content = user.Address;
            BalanceLabel.Content = user.Balance;
        }


    }
}
