using Microsoft.EntityFrameworkCore;
using model;

namespace dBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option)
        : base(option) { }

    public DbSet<Pessoa> pessoas { get; set; } = null!;
}
