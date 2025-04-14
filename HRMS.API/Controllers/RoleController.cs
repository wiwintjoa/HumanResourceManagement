using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly ILogger<RoleController> _logger;
		private readonly IRoleRepository _roleRepository;

		public RoleController(ILogger<RoleController> logger, IRoleRepository roleRepository)
		{
			_logger = logger;
			_roleRepository = roleRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Create(RoleDto roleDto)
		{
			if (roleDto == null)
			{
				return BadRequest();
			}

			await this._roleRepository.InsertAsync(roleDto);

			return Ok(roleDto);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<RoleDto>>> Get()
		{
			var roleDtos = await this._roleRepository.GetAllAsync();

			return Ok(roleDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetById(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var roleDto = await this._roleRepository.ReadAsync(id);
			if (roleDto == null)
			{
				return NotFound();
			}

			return Ok(roleDto);
		}

		[HttpPut]
		public async Task<ActionResult> Update(RoleDto roleDto)
		{
			if (roleDto == null)
			{
				return BadRequest();
			}

			var existingDto = await this._roleRepository.ReadAsync(roleDto.Id);
			if (existingDto == null)
			{
				return NotFound();
			}

			var updatedDto = await this._roleRepository.UpdateAsync(roleDto);

			return Ok(updatedDto);
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var roleDto = await this._roleRepository.ReadAsync(id);
			if (roleDto == null)
			{
				return NotFound();
			}

			await this._roleRepository.DeleteAsync(roleDto.Id);

			return Ok();
		}
	}
}
