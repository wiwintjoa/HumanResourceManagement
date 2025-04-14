using HRMS.Desktop.Models;
using HRMS.Desktop.Services;
using HRMS.Desktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace HRMS.Desktop.UserControls
{
	/// <summary>
	/// Interaction logic for RolePage.xaml
	/// </summary>
	public partial class RolePage : UserControl
	{
		private readonly RoleService _roleService = new RoleService();

		public RolePage()
		{
			InitializeComponent();
			DataContext = new RoleViewModel();
		}

		private async void CreateRoleButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedDepartment = DepartmentComboBox.SelectedItem as DepartmentModel;

			var role = new RoleModel
			{
				Title = TitleTextBox.Text,
				Description = DescriptionTextBox.Text,
				DepartmentId = selectedDepartment.Id,
			};

			await _roleService.CreateAsync(role);
			ReadRoleButton_Click(sender, e);
		}

		private async void ReadRoleButton_Click(object sender, RoutedEventArgs e)
		{
			var list = await _roleService.GetAllAsync();
			RoleGrid.ItemsSource = list;
		}

		private async void UpdateRoleButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedDepartment = DepartmentComboBox.SelectedItem as DepartmentModel;

			if (RoleGrid.SelectedItem is RoleModel role)
			{
				role.Title = TitleTextBox.Text;
				role.Description = DescriptionTextBox.Text;
				role.DepartmentId = selectedDepartment.Id;

				await _roleService.UpdateAsync(role);
				ReadRoleButton_Click(sender, e);
			}
		}

		private async void DeleteRoleButton_Click(object sender, RoutedEventArgs e)
		{

			if (RoleGrid.SelectedItem is RoleModel role)
			{
				await _roleService.DeleteAsync(role.Id);
				ReadRoleButton_Click(sender, e);
			}
		}
	}
}
