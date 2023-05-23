using CompanyAddressBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAddressBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
