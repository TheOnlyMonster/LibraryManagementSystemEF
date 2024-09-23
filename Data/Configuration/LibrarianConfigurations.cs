using LibraryManagementSystemEF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystemEF.Data.Configuration
{
    internal class LibrarianConfigurations : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Email).IsRequired();

            builder.Property(l => l.Name).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100);

            builder.Property(l => l.Password).IsRequired().HasColumnType("VARCHAR").HasMaxLength(30);

            builder.HasIndex(l => l.Email).IsUnique();

            builder.HasData(
                new Librarian
                {
                    Id = 1,
                    Name = "Ahmed Smith",
                    Email = "ahmedSmith@exmaple.com",
                    Password = "ahmed123",
                    Salary = 5000,
                    DateOfEmployment = DateTime.Now
                });
        }

    }
}
