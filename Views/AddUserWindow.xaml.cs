using Microsoft.VisualBasic.Logging;
using ProviderSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProviderSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            Cities = new ObservableCollection<City>(context.Cities);
        }
        public static ProviderDbContext context = new();
        public ObservableCollection<City> Cities;

        private void AddClient(object sender, RoutedEventArgs e)
        {
            User newClient = new()
            {
                Fio = Name.Text,
                Login = Login.Text,
                Password = Password.Text,
                Address = Address.Text,
                Balance = int.Parse(Balance.Text),
                IdCity = 1,
                Email = Email.Text,
                IdPosition = 3,
                BlockStatus = "Активен"
            };

            context.Users.Add(newClient);
            context.SaveChanges();

            MessageBox.Show("Вы успешно добавили нового клиента!",
                    "Клиент добавлен",
                    MessageBoxButton.OK,
                    MessageBoxImage.Question);
        }
    }
}
