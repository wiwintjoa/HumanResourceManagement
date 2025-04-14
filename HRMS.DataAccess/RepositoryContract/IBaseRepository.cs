namespace HRMS.DataAccess.RepositoryContract
{
	public interface IBaseRepository<TDto>
	{
		Task<IEnumerable<TDto>> GetAllAsync();

		Task<TDto> InsertAsync(TDto dto);

		Task<TDto> ReadAsync(object primaryKey);

		Task<TDto> UpdateAsync(TDto dto);

		Task<TDto> DeleteAsync(object primaryKey);

		Task<PagedSearchResult<TDto>> PagedSearchAsync(PagedSearchParameter parameter);
	}
}
