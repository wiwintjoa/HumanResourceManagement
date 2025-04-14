using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly ILogger<EmployeeController> _logger;
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
		{
			_logger = logger;
			_employeeRepository = employeeRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Create(EmployeeDto employeeDto)
		{
			if (employeeDto == null)
			{
				return BadRequest();
			}

			await this._employeeRepository.InsertAsync(employeeDto);

			return Ok(employeeDto);
		}

		[HttpGet]
		public async Task<ActionResult> GetById(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var employeeDto = await this._employeeRepository.ReadAsync(id);
			if (employeeDto == null)
			{
				return NotFound();
			}

			return Ok(employeeDto);
		}

		[HttpPut]
		public async Task<ActionResult> Update(EmployeeDto employeeDto)
		{
			if (employeeDto == null) { 
				return BadRequest();
			}

			var existingDto = await this._employeeRepository.ReadAsync(employeeDto.Id);
			if (existingDto == null)
			{
				return NotFound(); 
			}

			var updatedDto = await this._employeeRepository.UpdateAsync(employeeDto);

			return Ok(updatedDto);
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var employeeDto = await this._employeeRepository.ReadAsync(id);
			if (employeeDto == null)
			{
				return NotFound();
			}

			await this.Delete(employeeDto.Id);

			return Ok();
		}
	}

}
