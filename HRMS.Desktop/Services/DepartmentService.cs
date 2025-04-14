using HRMS.Desktop.Models;
using HRMS.Desktop.Utils;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRMS.Desktop.Services
{
	public class DepartmentService
	{
		#region declare httpclient

		private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(UtilsConstant.ApiUri) };

		#endregion

		#region Public Method

		public async Task<List<DepartmentModel>> GetAllAsync()
		{
			var json = await _httpClient.GetStringAsync("api/Department");
			return JsonConvert.DeserializeObject<List<DepartmentModel>>(json);
		}

		public async Task<DepartmentModel> GetByIdAsync(string path)
		{
			DepartmentModel model = new DepartmentModel();
			HttpResponseMessage response = await _httpClient.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				if (!string.IsNullOrEmpty(result))
				{
					model = JsonConvert.DeserializeObject<DepartmentModel>(result);
				}
			}

			return model;
		}

		public async Task<DepartmentModel> CreateAsync(DepartmentModel model)
		{
			this.PopulateAuditFieldsOnCreate(model);
			HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Department", model);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(result))
			{
				model = JsonConvert.DeserializeObject<DepartmentModel>(result);
			}

			return model;
		}

		public async Task<DepartmentModel> UpdateAsync(DepartmentModel model)
		{
			this.PopulateAuditFieldsOnCreate(model);
			HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Department", model);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(result))
			{
				model = JsonConvert.DeserializeObject<DepartmentModel>(result);
			}

			return model;

		}

		public async Task<HttpStatusCode> DeleteAsync(int id)
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Department?id={id}");

			return response.StatusCode;
		}

		#endregion

		#region Private Method

		protected void PopulateAuditFieldsOnCreate(DepartmentModel model)
		{
			var currentUtcTime = DateTime.UtcNow;

			model.CreatedBy = "system";
			model.CreatedDateTime = currentUtcTime;
			model.LastModifiedBy = "system";
			model.LastModifiedDateTime = currentUtcTime;
		}

		protected void PopulateAuditFieldsOnUpdate(DepartmentModel model)
		{
			var currentUtcTime = DateTime.UtcNow;

			model.LastModifiedBy = "system";
			model.LastModifiedDateTime = currentUtcTime;
		}

		#endregion
	}
}
