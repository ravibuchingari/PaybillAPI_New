using Microsoft.EntityFrameworkCore;

namespace PayBillApp.WinApp.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(ConstantVariables.SQLITE_CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Items>()
                .HasKey(item => item.ItemId);

            //modelBuilder.Entity<Items>().Property(item => item.LocalLanguage).HasColumnName("local_language_name");
        }

    }
}
