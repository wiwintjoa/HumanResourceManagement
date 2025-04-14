using AutoMapper;
using HRMS.DataAccess.Application;
using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;

namespace HRMS.DataAccess.Repository
{
	public class LocationRepository : BaseRepository<ApplicationContext, HrLocation, LocationDto>, ILocationRepository
	{
		#region Constructor

		public LocationRepository(ApplicationContext context, IMapper mapper)
		   : base(context, mapper)
		{
		}

		#endregion
	}
}
