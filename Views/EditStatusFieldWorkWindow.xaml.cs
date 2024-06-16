using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using ProviderSystem.Models;
using Window = System.Windows.Window;

namespace ProviderSystem.Views;

public partial class EditStatusFieldWorkWindow : Window
{
    public EditStatusFieldWorkWindow(FieldWork work)
    {
        _work = work;
        
        InitializeComponent();
        
        ComboBox.ItemsSource = new List<string>
        {
            "В ожидании",
            "В работе",
            "Завершено"
        };
    }

    private static readonly ProviderDbContext Context = new();
    private readonly FieldWork _work;
    private void EditStatus(object sender, RoutedEventArgs e)
    {
        _work.StatusOfWork = int.Parse(ComboBox.Text).ToString();
        Context.SaveChanges();
        MessageBox.Show("Статус изменен!", "Готово!", MessageBoxButton.OK);
        this.Close();
    }
    
}