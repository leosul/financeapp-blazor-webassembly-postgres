using FinanceApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.Api.Data.Mappings;

public class ExpenseMapping : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(s => s.Value)
            .IsRequired()
            .HasColumnType("decimal(18, 2)");

        builder.HasOne(s => s.Category)
            .WithMany(s => s.Expenses)
            .HasForeignKey(s => s.CategoryId)
            .IsRequired();

        builder.HasOne(s => s.User)
            .WithMany(s => s.Expenses)
            .HasForeignKey(s => s.UserId)
            .IsRequired();

        builder.Property(s => s.CreatedAt)
            .IsRequired()
            .HasColumnType("date");

        builder.HasIndex(s => s.Name).IsUnique(false);

        builder.ToTable("Expenses");
    }
}
