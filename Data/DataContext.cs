using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Issue> Issues { get; set; }
    }
}
