using AutoMapper;
using HRMS.DataAccess.Application;
using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;

namespace HRMS.DataAccess.Repository
{
	public class RoleRepository : BaseRepository<ApplicationContext, HrRole, RoleDto>, IRoleRepository
	{
		#region Constructor

		public RoleRepository(ApplicationContext context, IMapper mapper)
		   : base(context, mapper)
		{
		}

		#endregion
	}
}
