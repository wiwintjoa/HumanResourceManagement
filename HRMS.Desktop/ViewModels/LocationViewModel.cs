using HRMS.Desktop.Models;
using HRMS.Desktop.Services;
using HRMS.Desktop.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HRMS.Desktop.ViewModels
{
	public class LocationViewModel : INotifyPropertyChanged
	{
		private readonly LocationService _service = new();

		private readonly Dictionary<string, List<string>> countryCityMap = new()
		{
			["USA"] = new List<string> { "New York", "Los Angeles", "Chicago" },
			["UK"] = new List<string> { "London", "Manchester", "Birmingham" },
			["India"] = new List<string> { "Delhi", "Mumbai", "Bangalore" }
		};

		public ObservableCollection<LocationModel> Locations { get; set; } = new();
		public ObservableCollection<string> Countries { get; set; } = new();
		public ObservableCollection<string> Cities { get; set; } = new();

		public ICommand LoadCommand { get; }
		public ICommand CreateCommand { get; }
		public ICommand UpdateCommand { get; }
		public ICommand DeleteCommand { get; }

		private string? _selectedCountry;
		public string? SelectedCountry
		{
			get => _selectedCountry;
			set
			{
				_selectedCountry = value;
				OnPropertyChanged();
				UpdateCitiesForCountry(value);
				if (SelectedLocation != null)
					SelectedLocation.Country = value ?? string.Empty;
			}
		}

		private string? _selectedCity;
		public string? SelectedCity
		{
			get => _selectedCity;
			set
			{
				_selectedCity = value;
				OnPropertyChanged();
				if (SelectedLocation != null)
					SelectedLocation.City = value ?? string.Empty;
			}
		}

		private LocationModel _selectedLocation = new();

		public LocationModel SelectedLocation
		{
			get => _selectedLocation;
			set
			{
				_selectedLocation = value;
				OnPropertyChanged();
				if (value != null)
				{
					SelectedCountry = value.Country;
					SelectedCity = value.City;
				}
				else
				{
					SelectedCountry = null;
					SelectedCity = null;
				}
			}
		}

		public LocationViewModel()
		{
			LoadCommand = new RelayCommand(async () => await LoadLocations());
			CreateCommand = new RelayCommand(async () => await Create());
			UpdateCommand = new RelayCommand(async () =>
			{
				if (SelectedLocation != null)
				{
					await Update();
				}
			});
			DeleteCommand = new RelayCommand(async () => await Delete());

			Countries = new ObservableCollection<string>(countryCityMap.Keys);
		}

		private void UpdateCitiesForCountry(string? country)
		{
			Cities.Clear();
			if (country != null && countryCityMap.ContainsKey(country))
			{
				foreach (var city in countryCityMap[country])
					Cities.Add(city);
			}
		}

		private async Task LoadLocations()
		{
			var list = await _service.GetAllAsync();
			Locations.Clear();
			list.ForEach(loc => Locations.Add(loc));
		}

		private async Task Create()
		{
			await _service.CreateAsync(SelectedLocation);
			await LoadLocations();
		}

		private async Task Update()
		{
			await _service.UpdateAsync(SelectedLocation);
			await LoadLocations();
		}

		private async Task Delete()
		{
			await _service.DeleteAsync(SelectedLocation.Id);
			await LoadLocations();
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string? name = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
