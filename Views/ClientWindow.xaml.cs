using ProviderSystem.Models;
using ProviderSystem.Views.Pages;
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

namespace ProviderSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ObservableCollection<User> Users { get; private set; }
        public ClientWindow(User user)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            var context = new ProviderDbContext();
            User = context.Users.FirstOrDefault(u => u.IdUser == user.IdUser);
        }
        User User;
        private void GoToMyProfile(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new MyAccount(User));
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            var wnd = new LoginWindow();
            this.Close();
            wnd.Show();
        }
    }
}
