using System.Reflection;
using BookLoans.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLoans.Infra.Data
{
    public sealed class BookLoansContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Book> Books { get; set; }
        
        public BookLoansContext(DbContextOptions<BookLoansContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=BookLoans.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}