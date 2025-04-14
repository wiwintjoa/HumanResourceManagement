using HRMS.DataAccess.Repository;
using HRMS.DataAccess.RepositoryContract;

namespace HRMS.API
{
	public static class Bootstrapper
	{
		public static void SetupRepositories(this IServiceCollection services)
		{
			services.AddTransient<IEmployeeRepository, EmployeeRepository>();
			services.AddTransient<ILocationRepository, LocationRepository>();
			services.AddTransient<IRoleRepository, RoleRepository>();
			services.AddTransient<IDepartmentRepository, DepartmentRepository>();
			services.AddTransient<IJobHistoryRepository, JobHistoryRepository>();
		}
	}
}
