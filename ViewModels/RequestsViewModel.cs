using Microsoft.EntityFrameworkCore;
using ProviderSystem.Models;
using ProviderSystem.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProviderSystem.ViewModels
{
    public class RequestsViewModel : ViewModelBase
    {
        public static ProviderDbContext context = new();
        public RequestsViewModel()
        {
            Requests = new ObservableCollection<FieldWork>(context.FieldWorks
                .Include(r => r.IdUserNavigation)
                .Include(r => r.IdServiceNavigation));
            Services = new ObservableCollection<Service>(context.Services);

            Service allServices = new();
            allServices.Name = "Все услуги";
            Services.Add(allServices);
        }

        public ObservableCollection<FieldWork> Requests
        {
            get { return requests; }
            set
            {
                requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }
        public ObservableCollection<Service> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                OnPropertyChanged(nameof(Services));
            }
        }
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    SearchAndFilter();
                }
            }
        }

        public Service SelectedServices
        {
            get { return _selectedCity; }
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged(nameof(SelectedServices));
                    SearchAndFilter();
                }
            }
        }

        private void SearchAndFilter()
        {
            ////поиск
            //var query = context.Users.Where(u => u.IdPosition == 3)
            //    .Include(r => r.IdPositionNavigation)
            //    .Include(r => r.IdTariffPlanNavigation)
            //    .Include(r => r.IdCityNavigation)
            //    .AsQueryable();

            //if (!string.IsNullOrWhiteSpace(SearchText))
            //{
            //    query = query.Where(p => p.Fio.Contains(SearchText));
            //}

            ////фильтрация
            //if (SelectedCity != null)
            //{
            //    if (SelectedCity.Name == "Все города")
            //    {
            //        query = context.Users.Where(u => u.IdPosition == 3)
            //                            .Include(r => r.IdPositionNavigation)
            //                            .Include(r => r.IdTariffPlanNavigation)
            //                            .Include(r => r.IdCityNavigation)
            //                            .AsQueryable();
            //    }
            //    else
            //    {
            //        query = query.Where(s => s.IdCityNavigation.Name == SelectedCity.Name);
            //    }
            //}

            //var clients = query.ToList();


            //Services = new ObservableCollection<Service>(clients.Select(c => new User
            //{
            //    IdUser = c.IdUser,
            //    Fio = c.Fio,
            //    Email = c.Email,
            //    IdTariffPlanNavigation = GetTarifPlan(c.IdTariffPlan),
            //    Login = c.Login,
            //    Password = c.Password,
            //    Balance = c.Balance,
            //    IdPositionNavigation = GetPosition(c.IdPosition),
            //    IdCityNavigation = GetCity(c.IdCity),
            //    Address = c.Address,
            //    BlockStatus = c.BlockStatus
            //}));

        }
        private static User GetUser(int? id)
        {
            var user = context.Users.FirstOrDefault(c => c.IdUser == id);
            return new User
            {
                Fio = user.Fio
            };
        }
        private ObservableCollection<FieldWork> requests = new ObservableCollection<FieldWork>();
        private ObservableCollection<Service> _services = new ObservableCollection<Service>();
        private string searchText;
        private Service _selectedCity;
    }
}
