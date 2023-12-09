using BlazorCrudSampleSsr.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudSampleSsr.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    Id = 1,
                    Name = "Mahdi",
                    SirName = "Niknam",
                    PhoneNumber = "09939148774",
                },
                new Contact()
                {
                    Id = 2,
                    Name = "Hossein",
                    SirName = "Niknam",
                    PhoneNumber = "09196503294",
                },
                new Contact()
                {
                    Id = 3,
                    Name = "Hamid",
                    SirName = "Niknam",
                    PhoneNumber = "09191201455",
                });
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
