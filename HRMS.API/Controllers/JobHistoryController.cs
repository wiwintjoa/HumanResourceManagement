using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobHistoryController : ControllerBase
	{
		private readonly ILogger<JobHistoryController> _logger;
		private readonly IJobHistoryRepository _jobHistoryRepository;

		public JobHistoryController(ILogger<JobHistoryController> logger, IJobHistoryRepository jobHistoryRepository)
		{
			_logger = logger;
			_jobHistoryRepository = jobHistoryRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Create(JobHistoryDto jobHistoryDto)
		{
			if (jobHistoryDto == null)
			{
				return BadRequest();
			}

			await this._jobHistoryRepository.InsertAsync(jobHistoryDto);

			return Ok(jobHistoryDto);
		}

		[HttpGet]
		public async Task<ActionResult> GetById(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var jobHistoryDto = await this._jobHistoryRepository.ReadAsync(id);
			if (jobHistoryDto == null)
			{
				return NotFound();
			}

			return Ok(jobHistoryDto);
		}

		[HttpPut]
		public async Task<ActionResult> Update(JobHistoryDto jobHistoryDto)
		{
			if (jobHistoryDto == null)
			{
				return BadRequest();
			}

			var existingDto = await this._jobHistoryRepository.ReadAsync(jobHistoryDto.Id);
			if (existingDto == null)
			{
				return NotFound();
			}

			var updatedDto = await this._jobHistoryRepository.UpdateAsync(jobHistoryDto);

			return Ok(updatedDto);
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var jobHistoryDto = await this._jobHistoryRepository.ReadAsync(id);
			if (jobHistoryDto == null)
			{
				return NotFound();
			}

			await this.Delete(jobHistoryDto.Id);

			return Ok();
		}
	}
}
