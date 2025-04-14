using HRMS.Desktop.Models;
using HRMS.Desktop.Services;
using HRMS.Desktop.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HRMS.Desktop.ViewModels
{
	public class RoleViewModel : INotifyPropertyChanged
	{
		private readonly RoleService _service = new();
		private readonly DepartmentService _departmentService = new();

		public ObservableCollection<RoleModel> Roles { get; set; } = new();
		public ObservableCollection<DepartmentModel> Departments { get; set; } = new();

		private DepartmentModel? _selectedDepartment;
		public DepartmentModel? SelectedDepartment
		{
			get => _selectedDepartment;
			set
			{
				_selectedDepartment = value;
				OnPropertyChanged();
				if (SelectedRole != null && value != null)
					SelectedRole.DepartmentId = value.Id;
			}
		}

		public ICommand LoadCommand { get; }
		public ICommand CreateCommand { get; }
		public ICommand UpdateCommand { get; }
		public ICommand DeleteCommand { get; }

		
		private RoleModel _selectedRole = new();

		public RoleModel SelectedRole
		{
			get => _selectedRole;
			set
			{
				_selectedRole = value;
				OnPropertyChanged();
				SelectedDepartment = value?.Department;
			}
		}

		public RoleViewModel()
		{
			LoadCommand = new RelayCommand(async () => await LoadData());
			CreateCommand = new RelayCommand(async () => await Create());
			UpdateCommand = new RelayCommand(async () =>
			{
				if (SelectedRole != null)
				{
					await Update();
				}
			});
			DeleteCommand = new RelayCommand(async () => await Delete());

			_ = LoadData();
		}

		
		private async Task LoadData()
		{
			var depts = await _departmentService.GetAllAsync();
			Departments.Clear();
			foreach (var dept in depts) Departments.Add(dept);

			var list = await _service.GetAllAsync();
			Roles.Clear();
			list.ForEach(role => Roles.Add(role));
		}

		private async Task Create()
		{
			await _service.CreateAsync(SelectedRole);
			await LoadData();
		}

		private async Task Update()
		{
			await _service.UpdateAsync(SelectedRole);
			await LoadData();
		}

		private async Task Delete()
		{
			await _service.DeleteAsync(SelectedRole.Id);
			await LoadData();
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string? name = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
