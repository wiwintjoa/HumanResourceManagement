using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DepartmentController : ControllerBase
	{
		private readonly ILogger<DepartmentController> _logger;
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentController(ILogger<DepartmentController> logger, IDepartmentRepository departmentRepository)
		{
			_logger = logger;
			_departmentRepository = departmentRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Create(DepartmentDto departmentDto)
		{
			if (departmentDto == null)
			{
				return BadRequest();
			}

			await this._departmentRepository.InsertAsync(departmentDto);

			return Ok(departmentDto);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<LocationDto>>> Get()
		{
			var locationDtos = await this._departmentRepository.GetAllAsync();

			return Ok(locationDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetById(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var departmentDto = await this._departmentRepository.ReadAsync(id);
			if (departmentDto == null)
			{
				return NotFound();
			}

			return Ok(departmentDto);
		}

		[HttpPut]
		public async Task<ActionResult> Update(DepartmentDto departmentDto)
		{
			if (departmentDto == null)
			{
				return BadRequest();
			}

			var existingDto = await this._departmentRepository.ReadAsync(departmentDto.Id);
			if (existingDto == null)
			{
				return NotFound();
			}

			var updatedDto = await this._departmentRepository.UpdateAsync(departmentDto);

			return Ok(updatedDto);
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var departmentDto = await this._departmentRepository.ReadAsync(id);
			if (departmentDto == null)
			{
				return NotFound();
			}

			await this._departmentRepository.DeleteAsync(departmentDto.Id);

			return Ok();
		}
	}
}
