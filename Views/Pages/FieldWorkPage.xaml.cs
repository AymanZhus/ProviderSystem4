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
using ProviderSystem.Models;

namespace ProviderSystem.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для FieldWorkPage.xaml
    /// </summary>
    public partial class FieldWorkPage : Page
    {
        public FieldWorkPage()
        {
            InitializeComponent();
        }

        private void EditStatusBaseOnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is FieldWork fieldWork)
            {
                EditStatusFieldWorkWindow window = new(fieldWork);
                window.Show();
            }
        }

        private void AddRequestButtonClick(object sender, RoutedEventArgs e)
        {
            AddFieldworkWindow addFieldworkWindow = new AddFieldworkWindow();
            addFieldworkWindow.Show();
        }
    }
}
