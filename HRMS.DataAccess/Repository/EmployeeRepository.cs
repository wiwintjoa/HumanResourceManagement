using AutoMapper;
using HRMS.DataAccess.Application;
using HRMS.DataAccess.Dto;
using HRMS.DataAccess.RepositoryContract;

namespace HRMS.DataAccess.Repository
{
	public class EmployeeRepository : BaseRepository<ApplicationContext, HrEmployee, EmployeeDto>, IEmployeeRepository
	{
		#region Constructor

		public EmployeeRepository(ApplicationContext context, IMapper mapper)
		   : base(context, mapper)
		{
		}

		#endregion
	}
}
