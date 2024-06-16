using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using ProviderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Design;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using User = ProviderSystem.Models.User;

namespace ProviderSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddFieldworkWindow.xaml
    /// </summary>
    public partial class AddFieldworkWindow : Window
    {
        private static readonly ProviderDbContext Context = new();
        public AddFieldworkWindow()
        {
            InitializeComponent();
            Client.ItemsSource = new List<User>(Context.Users.Where(u => u.IdPosition == 3));
            Worker.ItemsSource = new List<User>(Context.Users.Where(u => u.IdPosition == 2));
            Service.ItemsSource = new List<Service>(Context.Services);
            Status.ItemsSource = new List<string>
            {
                "В ожидании",
                "В работе",
                "Завершено"
            };
        }

        private void AddRequest(object sender, RoutedEventArgs e)
        {
            var IdUser = (User)Client.SelectedItem;
            var IdWorker = (User)Worker.SelectedItem;
            var IdService = (Service)Service.SelectedItem;
            FieldWork newFiledWork = new()
            {
                IdUser = IdUser.IdUser,
                IdWorker = IdWorker.IdUser,
                IdService = IdService.IdService,
                Price = int.Parse(Price.Text),
                StatusOfWork = Status.SelectedItem.ToString()//проверку на null надо всем полям 
            };

            Context.FieldWorks.Add(newFiledWork);
            Context.SaveChanges();

            MessageBox.Show("Вы успешно добавили новую запись!",
                    "Запись добавлена",
                    MessageBoxButton.OK,
                    MessageBoxImage.Question);
        }
    }
}
