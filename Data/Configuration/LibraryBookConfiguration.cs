using LibraryManagementSystemEF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemEF.Data.Configuration
{
    internal class LibraryBookConfiguration : IEntityTypeConfiguration<LibraryBook>
    {
        public void Configure(EntityTypeBuilder<LibraryBook> builder)
        {

            builder.HasKey(b => b.BookId);

            builder.Property(b => b.Quantity).IsRequired();

            builder.HasOne(b => b.Book).WithOne().HasForeignKey<LibraryBook>(b => b.BookId).OnDelete(DeleteBehavior.Cascade);
            
            builder.HasData(LoadLibraryBooks());
        }

        private LibraryBook[] LoadLibraryBooks()
        {
            return new LibraryBook[] {
                new LibraryBook( )
                {
                    BookId = 1,
                    Quantity = 10
                },
                new LibraryBook( )
                {
                    BookId = 2,
                    Quantity = 10
                },
                new LibraryBook( )
                {
                    BookId = 3,
                    Quantity = 10
                },
            };
        }
    }

}
