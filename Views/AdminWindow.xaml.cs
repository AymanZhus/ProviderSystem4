using Microsoft.VisualBasic.ApplicationServices;
using ProviderSystem.Models;
using ProviderSystem.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
using User = ProviderSystem.Models.User;

namespace ProviderSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public ObservableCollection<User> Users { get; private set; }
        public AdminWindow(User user)
        {
            InitializeComponent();
            User = user;
            WindowState = WindowState.Maximized;
        }
        User User;
        private void goToClientsPage(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Views/Pages/UsersPage.xaml", UriKind.Relative));
        }

        private void toToTariffPage(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Views/Pages/TariffsPage.xaml", UriKind.Relative));
        }

        private void toToJournalPage(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Views/Pages/JournalPage.xaml", UriKind.Relative));
        }

        private void toToBillPage(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Views/Pages/BillsPage.xaml", UriKind.Relative));
        }

        private void goToRequestsPage(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Views/Pages/FieldWorkPage.xaml", UriKind.Relative));
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            var wnd = new LoginWindow();
            this.Close();
            wnd.Show();
        }
    }
}
