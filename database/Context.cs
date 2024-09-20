using code_dotnet.entities;
using Microsoft.EntityFrameworkCore;

namespace code_dotnet.database
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {

        public DbSet<UserEntity> UserEntity { get; set; }
    }
}
