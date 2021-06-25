using BookLoans.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLoans.Infra.Data.Configurations
{
    public class LoansConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans").HasKey(l => l.Id);

            builder.HasIndex(l => l.Id);

            builder.Property(l => l.User);

            builder.HasOne(l => l.Book)
                .WithOne(l => l.Loan);
        }
    }
}