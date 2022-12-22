using FinanceApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.Api.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(s => s.CreatedAt)
            .IsRequired()
            .HasColumnType("date");

        builder.HasIndex(s => s.Name).IsUnique(false);

        builder.ToTable("Users");
    }
}
