using ProviderSystem.Models;
using ProviderSystem.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProviderSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            using (var context = new ProviderDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null && user.IdPosition == 1)
                {
                    var wnd = new AdminWindow(user.IdUser);
                    this.Close();
                    wnd.Show();
                }
                else if (user != null && user.IdPosition == 2)
                {
                    MessageBox.Show("Специалист", "Специалист!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (user != null && user.IdPosition == 3)
                {
                    MessageBox.Show("Клиент", "Клиент!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Неверные данные входа!", "Вход не выполнен!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}