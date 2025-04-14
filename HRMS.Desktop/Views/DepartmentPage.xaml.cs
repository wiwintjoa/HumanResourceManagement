using HRMS.Desktop.Models;
using HRMS.Desktop.Services;
using HRMS.Desktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace HRMS.Desktop.UserControls
{
	/// <summary>
	/// Interaction logic for DepartmentPage.xaml
	/// </summary>
	public partial class DepartmentPage : UserControl
	{
		private readonly DepartmentService _departmentService = new DepartmentService();

		public DepartmentPage()
		{
			InitializeComponent();
			DataContext = new DepartmentViewModel();
		}

		private async void CreateDepartmentButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedLocation = LocationComboBox.SelectedItem as LocationModel;

			var dept = new DepartmentModel
			{
				Name = NameTextBox.Text,
				Description = DescriptionTextBox.Text,
				LocationId = selectedLocation.Id,
			};

			await _departmentService.CreateAsync(dept);
			ReadDepartmentButton_Click(sender, e);
		}

		private async void ReadDepartmentButton_Click(object sender, RoutedEventArgs e)
		{
			var list = await _departmentService.GetAllAsync();
			DepartmentGrid.ItemsSource = list;

		}

		private async void UpdateDepartmentButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedLocation = LocationComboBox.SelectedItem as LocationModel;

			if (DepartmentGrid.SelectedItem is DepartmentModel dept)
			{
				dept.Name = NameTextBox.Text;
				dept.Description = DescriptionTextBox.Text;
				dept.LocationId = selectedLocation.Id;

				await _departmentService.UpdateAsync(dept);
				ReadDepartmentButton_Click(sender, e);
			}
		}

		private async void DeleteDepartmentButton_Click(object sender, RoutedEventArgs e)
		{
			if (DepartmentGrid.SelectedItem is DepartmentModel dept)
			{
				await _departmentService.DeleteAsync(dept.Id);
				ReadDepartmentButton_Click(sender, e);
			}
		}
	}
}
