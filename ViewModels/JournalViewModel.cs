using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ProviderSystem.ViewModels
{
    public class JournalViewModel: ViewModelBase
    {
        public JournalViewModel() 
        {
            Journals = new ObservableCollection<Journal>(context.Journals
                .Include(r => r.IdEventNavigation)
                .Include(r => r.IdTariffPlanNavigation)
                .Include(r => r.IdUserNavigation));

            Events = new ObservableCollection<Event>(context.Events);
        }
        public ProviderDbContext context = new();

        public ObservableCollection<Journal> Journals
        {
            get { return journals; }
            set
            {
                journals = value;
                OnPropertyChanged(nameof(Journal));
            }
        }

        public ObservableCollection<Event> Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged(nameof(Event));
            }
        }

        public ObservableCollection<TariffPlan> TariffPlans
        {
            get { return tariffPlans; }
            set
            {
                tariffPlans = value;
                OnPropertyChanged(nameof(TariffPlan));
            }
        }

        private ObservableCollection<Journal> journals = new ObservableCollection<Journal>();
        private ObservableCollection<Event> events = new ObservableCollection<Event>();
        private ObservableCollection<TariffPlan> tariffPlans= new ObservableCollection<TariffPlan>();
        private ObservableCollection<User> users = new ObservableCollection<User>();
    }
}
