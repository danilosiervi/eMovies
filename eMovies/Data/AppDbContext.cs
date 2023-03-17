using Microsoft.EntityFrameworkCore;

namespace eMovies.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


}
