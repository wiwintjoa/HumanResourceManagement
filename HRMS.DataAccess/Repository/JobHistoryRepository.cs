using AutoMapper;
using HRMS.DataAccess.Application;
using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;

namespace HRMS.DataAccess.Repository
{
	public class JobHistoryRepository : BaseRepository<ApplicationContext, HrJobHistory, JobHistoryDto>, IJobHistoryRepository
	{
		#region Constructor

		public JobHistoryRepository(ApplicationContext context, IMapper mapper)
		   : base(context, mapper)
		{
		}

		#endregion
	}
}
