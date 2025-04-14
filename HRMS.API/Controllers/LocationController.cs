using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly ILogger<LocationController> _logger;
		private readonly ILocationRepository _locationRepository;

		public LocationController(ILogger<LocationController> logger, ILocationRepository locationRepository)
		{
			_logger = logger;
			_locationRepository = locationRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Create(LocationDto locationDto)
		{
			if (locationDto == null)
			{
				return BadRequest();
			}

			await this._locationRepository.InsertAsync(locationDto);

			return Ok(locationDto);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<LocationDto>>> Get()
		{
			var locationDtos = await this._locationRepository.GetAllAsync();

			return Ok(locationDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var locationDto = await this._locationRepository.ReadAsync(id);
			if (locationDto == null)
			{
				return NotFound();
			}

			return Ok(locationDto);
		}

		[HttpPut]
		public async Task<ActionResult> Update(LocationDto locationDto)
		{
			if (locationDto == null)
			{
				return BadRequest();
			}

			var existingDto = await this._locationRepository.ReadAsync(locationDto.Id);
			if (existingDto == null)
			{
				return NotFound();
			}

			var updatedDto = await this._locationRepository.UpdateAsync(locationDto);

			return Ok(updatedDto);
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var locationDto = await this._locationRepository.ReadAsync(id);
			if (locationDto == null)
			{
				return NotFound();
			}

			await this._locationRepository.DeleteAsync(locationDto.Id);

			return Ok();
		}
	}
}
