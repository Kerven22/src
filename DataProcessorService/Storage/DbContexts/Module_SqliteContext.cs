using DataProcessorService.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProcessorService.Storage.DbContexts
{
    public class Module_SqliteContext:DbContext
    {
        public DbSet<Modules> Modules { get; set; }
          
        public Module_SqliteContext(DbContextOptions<Module_SqliteContext> options):base(options)
        {
        }
    }
}
