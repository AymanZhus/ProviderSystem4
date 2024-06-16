using ProviderSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProviderSystem.ViewModels
{
    public class BillViewModel: ViewModelBase
    {
        public BillViewModel()
        {
            Bills = new ObservableCollection<Bill>(context.Bills
                .Include(r => r.IdUserNavigation));
        }
        public ProviderDbContext context = new();

        public ObservableCollection<Bill> Bills
        {
            get { return bills; }
            set
            {
                bills = value;
                OnPropertyChanged(nameof(Bill));
            }
        }

        private ObservableCollection<Bill> bills = new ObservableCollection<Bill>();
        private ObservableCollection<User> users = new ObservableCollection<User>();
    }
}
