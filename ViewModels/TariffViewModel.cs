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

            // Проходимся по каждому тарифу
            foreach (var tariff in Tariffs)
            {
                // Получаем все оценки для текущего тарифа из таблицы UserRating
                var ratingsForTariff = context.UserRatings.Where(ur => ur.IdTariffPlan == tariff.IdTariffPlan).ToList();

                // Вычисляем среднюю оценку
                if (ratingsForTariff.Any())
                {
                    double averageRating = ratingsForTariff.Average(ur => ur.Mark);
                    tariff.Rating = (int)averageRating;
                }
                else
                {
                    // Если для тарифа нет оценок, можно установить дефолтное значение или оставить как есть
                    tariff.Rating = 0; // Например, устанавливаем рейтинг 0
                }
            }
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
