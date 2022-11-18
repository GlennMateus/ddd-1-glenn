#region

using backend.domain.Models;

#endregion

namespace backend.Infra.Repositories.Interfaces;

public interface IPostalCodesRepository
{
    Task AddAsync(PostalCodes postalCode);
    Task<List<PostalCodes>> GetAllAsync();
    Task<List<PostalCodes>> GetLastThreeAsync();
}