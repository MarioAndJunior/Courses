using System.Collections.ObjectModel;
using System.ComponentModel;
using WheaterApp.Model;
using WheaterApp.ViewModel.Commands;
using WheaterApp.ViewModel.Helpers;

namespace WheaterApp.ViewModel
{
    public class WheaterViewModel : INotifyPropertyChanged
    {
        private readonly bool IsInDesignMode;
        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                if (value != null && selectedCity != value)
                {
                    selectedCity = value;
                    OnPropertyChanged(nameof(SelectedCity));
                    GetCurrentConditions();
                }
            }
        }

        public SearchCommand SearchCommand { get; set; }
        public ObservableCollection<City> Cities { get; set; }

        public WheaterViewModel()
        {
            this.IsInDesignMode = DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
            
            if (this.IsInDesignMode)
            {
                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };

                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Partly Cloud",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = 21
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        public async void MakeQuery()
        {
            var cities = await AccuWheaterHelper.GetCities(Query);
            
            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void GetCurrentConditions()
        {
            if (!this.IsInDesignMode)
            {
                Query = string.Empty;
                Cities.Clear();
                CurrentConditions = await AccuWheaterHelper.GetCurrentConditions(SelectedCity.Key);
            }
        }
    }
}
