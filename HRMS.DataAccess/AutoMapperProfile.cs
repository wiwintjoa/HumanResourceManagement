using AutoMapper;
using HRMS.DataAccess.Application;
using HRMS.DataAccess.Dto;

namespace HRMS.DataAccess
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile() {
			this.CreateMap<HrEmployee, EmployeeDto>().ReverseMap();
			this.CreateMap<HrDepartment, DepartmentDto>().ReverseMap();
			this.CreateMap<HrLocation, LocationDto>().ReverseMap();
			this.CreateMap<HrJobHistory, JobHistoryDto>().ReverseMap();
			this.CreateMap<HrRole, RoleDto>().ReverseMap();
		}
	}
}
