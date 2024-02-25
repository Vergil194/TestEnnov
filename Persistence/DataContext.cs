using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<Company> Companys { get; set; }

        public DbSet<CompanyAdresses> CompanyAdresses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>().HasKey(c => c.Uid);
            builder.Entity<CompanyAdresses>().HasKey(ca => ca.CompanyUid);

            builder.Entity<Company>()
                .HasOne(c => c.Adresses)
                .WithOne(ca => ca.Company)
                .HasForeignKey<CompanyAdresses>(c => c.CompanyUid);


        }
    }
}
