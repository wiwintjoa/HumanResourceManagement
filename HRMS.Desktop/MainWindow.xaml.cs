using HRMS.Desktop.UserControls;
using System.Diagnostics;
using System.Windows;

namespace HRMS.Desktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		EmployeePage employeePage = new EmployeePage();
		DepartmentPage departmentPage = new DepartmentPage();
		LocationPage locationPage = new LocationPage();
		RolePage rolePage = new RolePage();
		JobHistoryPage jobHistoryPage = new JobHistoryPage();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void LocationsButton_Click(object sender, RoutedEventArgs e)
		{
			MainDisplay.Content = locationPage;
		}

		private void DepartmentsButton_Click(object sender, RoutedEventArgs e)
		{
			MainDisplay.Content = departmentPage;
		}

		private void RolesButton_Click(object sender, RoutedEventArgs e)
		{
			MainDisplay.Content = rolePage;
		}

		private void EmployeesButton_Click(object sender, RoutedEventArgs e)
		{
			MainDisplay.Content = employeePage;
		}

		private void JobHistoriesButton_Click(object sender, RoutedEventArgs e)
		{
			MainDisplay.Content = jobHistoryPage;
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			App.Current.Shutdown();
			Process.GetCurrentProcess().Kill();
		}
	}
}