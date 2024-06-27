using ContactManager.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace ContactManager.Infrastructure
{
    public class CMDbContext : DbContext
    {
        private readonly IDbSeeder _dataSeeder;
        public CMDbContext(DbContextOptions<CMDbContext> options, IDbSeeder dataSeeder) : base(options)
        {
            _dataSeeder = dataSeeder;
        }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
