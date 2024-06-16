using Microsoft.VisualBasic.ApplicationServices;
using ProviderSystem.Models;
using ProviderSystem.Views.Pages;
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

namespace ProviderSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private int Userid;
        public AdminWindow(int idUser)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.Userid = idUser;
            using (var db = new ProviderDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.IdUser == idUser);

                if (user != null)
                {
                    // Теперь у вас есть объект user с данными пользователя, которые вы можете использовать на втором окне
                    // Например, вы можете отобразить какие-то данные из объекта user на вашем втором окне
                    //FIOtextbox.Text = FIOtextbox.Text + " " + user.Fio;
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

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
    }
}
