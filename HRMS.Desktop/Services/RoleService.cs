using HRMS.Desktop.Models;
using HRMS.Desktop.Utils;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRMS.Desktop.Services
{
	public class RoleService
	{
		#region declare httpclient

		private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(UtilsConstant.ApiUri) };

		#endregion

		#region Public Method

		public async Task<List<RoleModel>> GetAllAsync()
		{
			var json = await _httpClient.GetStringAsync("api/Role");
			return JsonConvert.DeserializeObject<List<RoleModel>>(json);
		}

		public async Task<RoleModel> GetByIdAsync(string path)
		{
			RoleModel model = new RoleModel();
			HttpResponseMessage response = await _httpClient.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				if (!string.IsNullOrEmpty(result))
				{
					model = JsonConvert.DeserializeObject<RoleModel>(result);
				}
			}

			return model;
		}

		public async Task<RoleModel> CreateAsync(RoleModel model)
		{
			this.PopulateAuditFieldsOnCreate(model);
			HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Role", model);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(result))
			{
				model = JsonConvert.DeserializeObject<RoleModel>(result);
			}

			return model;
		}

		public async Task<RoleModel> UpdateAsync(RoleModel model)
		{
			this.PopulateAuditFieldsOnCreate(model);
			HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Role", model);
			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(result))
			{
				model = JsonConvert.DeserializeObject<RoleModel>(result);
			}

			return model;

		}

		public async Task<HttpStatusCode> DeleteAsync(int id)
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Role?id={id}");

			return response.StatusCode;
		}

		#endregion

		#region Private Method

		protected void PopulateAuditFieldsOnCreate(RoleModel model)
		{
			var currentUtcTime = DateTime.UtcNow;

			model.CreatedBy = "system";
			model.CreatedDateTime = currentUtcTime;
			model.LastModifiedBy = "system";
			model.LastModifiedDateTime = currentUtcTime;
		}

		protected void PopulateAuditFieldsOnUpdate(RoleModel model)
		{
			var currentUtcTime = DateTime.UtcNow;

			model.LastModifiedBy = "system";
			model.LastModifiedDateTime = currentUtcTime;
		}

		#endregion
	}
}
