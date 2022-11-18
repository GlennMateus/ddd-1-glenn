#region

using backend.domain.Models;

#endregion

namespace backend.services.Interfaces;

public interface ICallPostCodes
{
    Task<PostalCodes> ExecuteAsync(string postcode);
}