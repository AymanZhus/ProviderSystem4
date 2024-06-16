using Microsoft.EntityFrameworkCore;
using ProviderSystem.Models;
using ProviderSystem.Views;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProviderSystem.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        public ClientViewModel()
        {
            Clients = new ObservableCollection<User>(context.Users.Where(u => u.IdPosition == 3)
                .Include(r => r.IdPositionNavigation)
                .Include(r => r.IdTariffPlanNavigation)
                .Include(r => r.IdCityNavigation));

            Cities = new ObservableCollection<City>(context.Cities);

            City allCity = new City();
            allCity.Name = "Все города";
            Cities.Add(allCity);
        }
        public static ProviderDbContext context = new();
        public ObservableCollection<User> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }
        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set
            {
                cities = value;
                OnPropertyChanged(nameof(Cities));
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

        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged(nameof(SelectedCity));
                    SearchAndFilter();
                }
            }
        }
        private void SearchAndFilter()
        {
            //поиск
            var query = context.Users.Where(u => u.IdPosition == 3)
                .Include(r => r.IdPositionNavigation)
                .Include(r => r.IdTariffPlanNavigation)
                .Include(r => r.IdCityNavigation)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(p => p.Fio.Contains(SearchText));
            }

            //фильтрация
            if (SelectedCity != null)
            {
                if (SelectedCity.Name == "Все города")
                {
                    query = context.Users.Where(u => u.IdPosition == 3)
                                        .Include(r => r.IdPositionNavigation)
                                        .Include(r => r.IdTariffPlanNavigation)
                                        .Include(r => r.IdCityNavigation)
                                        .AsQueryable();
                }
                else
                {
                    query = query.Where(s => s.IdCityNavigation.Name == SelectedCity.Name);
                }
            }

            var clients = query.ToList();


            Clients = new ObservableCollection<User>(clients.Select(c => new User
            {
                IdUser = c.IdUser,
                Fio = c.Fio,
                Email = c.Email,
                IdTariffPlanNavigation = GetTarifPlan(c.IdTariffPlan),
                Login = c.Login,
                Password = c.Password,
                Balance = c.Balance,
                IdPositionNavigation = GetPosition(c.IdPosition),
                IdCityNavigation = GetCity(c.IdCity),
                Address = c.Address,
                BlockStatus = c.BlockStatus
            }));

        }

        private static TariffPlan GetTarifPlan(int? id)
        {
            var plan = context.TariffPlans.FirstOrDefault(c => c.IdTariffPlan == id);
            return new TariffPlan
            {
                Name = plan.Name
            };
        }
        private static Position GetPosition(int id)
        {
            var pos = context.Positions.FirstOrDefault(c => c.IdPosition == id);
            return new Position
            {
                Name = pos.Name
            };
        }
        private static City GetCity(int id)
        {
            var city = context.Cities.FirstOrDefault(c => c.IdCity == id);
            return new City
            {
                Name = city.Name
            };
        }

        private ObservableCollection<User> clients = new ObservableCollection<User>();
        private ObservableCollection<City> cities = new ObservableCollection<City>();
        private string searchText;
        private City _selectedCity;
    }
}
