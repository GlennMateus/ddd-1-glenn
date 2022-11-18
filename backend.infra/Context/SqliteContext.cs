#region

using backend.domain.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace backend.infra.Context;

public class Sqlitecontext : DbContext
{
    public DbSet<PostalCodes> PostalCodes { get; set; }

    public Sqlitecontext(DbContextOptions options) : base(options)
    {
        
    }
}