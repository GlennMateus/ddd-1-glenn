#region

using backend.domain.Models;
using backend.infra.Context;
using backend.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

#endregion

namespace backend.Infra.Repositories.Implementations;

public class PostalCodesRepository : IPostalCodesRepository
{
    private readonly Sqlitecontext _context;

    public PostalCodesRepository(Sqlitecontext context)
    {
        _context = context;
    }

    public async Task AddAsync(PostalCodes postalCode)
    {
        try
        {
            _context.PostalCodes.Add(postalCode);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<PostalCodes>> GetAllAsync()
    {
        try
        {
            return await _context.PostalCodes.ToListAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<PostalCodes>> GetLastThreeAsync()
    {
        try
        {
            return await _context.PostalCodes.OrderByDescending(x => x.Id).Take(3).ToListAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}