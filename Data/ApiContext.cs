using Microsoft.EntityFrameworkCore;
using JobSearch.Models;


namespace JobSearch.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Job> JobSrch{ get; set; }
      
   
        public DbSet<department> dpt { get; set; }

        public DbSet<location> location { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
        {

        }

    }
}
