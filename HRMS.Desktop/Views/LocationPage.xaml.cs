using HRMS.Desktop.Models;
using HRMS.Desktop.Services;
using HRMS.Desktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace HRMS.Desktop.UserControls
{
	/// <summary>
	/// Interaction logic for LocationPage.xaml
	/// </summary>
	public partial class LocationPage : UserControl
	{
		private readonly LocationService _locationService = new LocationService();

		public LocationPage()
		{
			InitializeComponent();
			DataContext = new LocationViewModel();
		}

		private async void CreateLocationButton_Click(object sender, RoutedEventArgs e)
		{
			var loc = new LocationModel
			{
				Name = NameTextBox.Text,
				Country = CountryBox.SelectedItem?.ToString(),
				City = CityBox.SelectedItem?.ToString()
			};

			await _locationService.CreateAsync(loc);
			ReadLocationButton_Click(sender, e);
		}

		private async void ReadLocationButton_Click(object sender, RoutedEventArgs e)
		{
			var list = await _locationService.GetAllAsync();
			LocationGrid.ItemsSource = list;
		}

		private async void UpdateLocationButton_Click(object sender, RoutedEventArgs e)
		{
			if (LocationGrid.SelectedItem is LocationModel loc)
			{
				loc.Name = NameTextBox.Text;
				loc.Country = CountryBox.SelectedItem?.ToString();
				loc.City = CityBox.SelectedItem?.ToString();

				await _locationService.UpdateAsync(loc);
				ReadLocationButton_Click(sender, e);
			}
		}

		private async void DeleteLocationButton_Click(object sender, RoutedEventArgs e)
		{
			if (LocationGrid.SelectedItem is LocationModel loc)
			{
				await _locationService.DeleteAsync(loc.Id);
				ReadLocationButton_Click(sender, e);
			}
		}
	}
}
