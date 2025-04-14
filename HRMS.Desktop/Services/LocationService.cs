using HRMS.Desktop.Models;
using HRMS.Desktop.Utils;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRMS.Desktop.Services
{
	public class LocationService
	{
		#region declare httpclient

		private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(UtilsConstant.ApiUri) };

		#endregion

		#region Public Method

		public async Task<List<LocationModel>> GetAllAsync()
		{
			var json = await _httpClient.GetStringAsync("api/Location");
			return JsonConvert.DeserializeObject<List<LocationModel>>(json);
		}

		public async Task<LocationModel> GetByIdAsync(string path)
		{
			LocationModel model = new LocationModel();
			HttpResponseMessage response = await _httpClient.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				if (!string.IsNullOrEmpty(result))
				{
					model = JsonConvert.DeserializeObject<LocationModel>(result);
				}
			}

			return model;
		}

		public async Task<LocationModel> CreateAsync(LocationModel model)
		{
			this.PopulateAuditFieldsOnCreate(model);
			HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Location", model);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(result))
			{
				model = JsonConvert.DeserializeObject<LocationModel>(result);
			}

			return model;
		}

		public async Task<LocationModel> UpdateAsync(LocationModel model)
		{
			this.PopulateAuditFieldsOnCreate(model);
			HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Location", model);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(result))
			{
				model = JsonConvert.DeserializeObject<LocationModel>(result);
			}

			return model;

		}

		public async Task<HttpStatusCode> DeleteAsync(int id)
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Location?id={id}");

			return response.StatusCode;
		}

		#endregion

		#region Private Method

		protected void PopulateAuditFieldsOnCreate(LocationModel model) { 
			var currentUtcTime = DateTime.UtcNow;

			model.CreatedBy = "system";
			model.CreatedDateTime = currentUtcTime;
			model.LastModifiedBy = "system";
			model.LastModifiedDateTime = currentUtcTime;
		}

		protected void PopulateAuditFieldsOnUpdate(LocationModel model)
		{
			var currentUtcTime = DateTime.UtcNow;

			model.LastModifiedBy = "system";
			model.LastModifiedDateTime = currentUtcTime;
		}

		#endregion
	}
}
