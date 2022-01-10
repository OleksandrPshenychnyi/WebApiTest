using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Models
{
    public class ProgContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public ProgContext(DbContextOptions<ProgContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().Property(x => x.IncidentName).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Account>().HasIndex(n => n.AccountName).IsUnique();

            modelBuilder.Entity<Account>()
            .HasOne(n => n.Incident)
            .WithMany(a => a.Accounts);
            
            
            modelBuilder.Entity<Contact>()
                .HasOne(p => p.Account)
                .WithMany(b => b.Contacts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
