using AutoMapper;
using HRMS.DataAccess.Application;
using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;

namespace HRMS.DataAccess.Repository
{
	public class DepartmentRepository : BaseRepository<ApplicationContext, HrDepartment, DepartmentDto>, IDepartmentRepository
	{
		#region Constructor

		public DepartmentRepository(ApplicationContext context, IMapper mapper)
		   : base(context, mapper)
		{
		}

		#endregion
	}
}
