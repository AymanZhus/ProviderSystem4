using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProviderSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using ProviderSystem.Views;

namespace ProviderSystem.ViewModels
{
    public class TariffViewModel: ViewModelBase
    {
        public TariffViewModel()
        {
            Tariffs = new ObservableCollection<TariffPlan>(context.TariffPlans);
        }

        public ProviderDbContext context = new();
        public ICommand GoToAddTariffPlanWindowCommand {  get; set; }
        public ObservableCollection<TariffPlan> Tariffs
        {
            get { return tariffs; }
            set
            {
                tariffs = value;
                OnPropertyChanged(nameof(TariffPlan));
            }
        }

        private void GoToAddTariffPlanWindow()
        {
            AddTariffPlanWindow addTariffPlanWindow = new();
            addTariffPlanWindow.Show();
        }

        private ObservableCollection<TariffPlan> tariffs = new ObservableCollection<TariffPlan>();
    }
}
