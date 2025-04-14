using HRMS.Desktop.Models;
using HRMS.Desktop.Services;
using HRMS.Desktop.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HRMS.Desktop.ViewModels
{
	public class DepartmentViewModel
	{
		private readonly DepartmentService _service = new();
		private readonly LocationService _locationService = new();

		public ObservableCollection<DepartmentModel> Departments { get; set; } = new();
		public ObservableCollection<LocationModel> Locations { get; set; } = new();

		private LocationModel? _selectedLocation;
		public LocationModel? SelectedLocation
		{
			get => _selectedLocation;
			set
			{
				_selectedLocation = value;
				OnPropertyChanged();
				if (SelectedDepartment != null && value != null)
					SelectedDepartment.LocationId = value.Id;
			}
		}

		public ICommand LoadCommand { get; }
		public ICommand CreateCommand { get; }
		public ICommand UpdateCommand { get; }
		public ICommand DeleteCommand { get; }


		private DepartmentModel _selectedDepartment = new();
		public DepartmentModel SelectedDepartment
		{
			get => _selectedDepartment;
			set
			{
				_selectedDepartment = value;
				OnPropertyChanged();
				SelectedLocation = value?.Location;
			}
		}

		public DepartmentViewModel()
		{
			LoadCommand = new RelayCommand(async () => await LoadData());
			CreateCommand = new RelayCommand(async () => await Create());
			UpdateCommand = new RelayCommand(async () =>
			{
				if (SelectedDepartment != null)
				{
					await Update();
				}
			});
			DeleteCommand = new RelayCommand(async () => await Delete());

			_ = LoadData();
		}

		private async Task LoadData()
		{
			var locs = await _locationService.GetAllAsync();
			Locations.Clear();
			foreach (var loc in locs) Locations.Add(loc);

			var depts = await _service.GetAllAsync();
			Departments.Clear();
			foreach (var dept in depts) Departments.Add(dept);
		}

		private async Task Create()
		{
			await _service.CreateAsync(SelectedDepartment);
			await LoadData();
		}

		private async Task Update()
		{
			await _service.UpdateAsync(SelectedDepartment);
			await LoadData();
		}

		private async Task Delete()
		{
			await _service.DeleteAsync(SelectedDepartment.Id);
			await LoadData();
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string? name = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
