﻿// <auto-generated />
using System;
using LibraryManagementSystemEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystemEF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240923013433_AddedEntitiesMemberAndBorrowedBooks")]
    partial class AddedEntitiesMemberAndBorrowedBooks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Author One Biography",
                            Email = "AuthorOne@exmaple.com",
                            Name = "Author One",
                            Password = "password"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Author Two Biography",
                            Email = "AuthorTwo@exmaple.com",
                            Name = "Author Two",
                            Password = "password"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "Author Three Biography",
                            Email = "AuthorThree@exmaple.com",
                            Name = "Author Three",
                            Password = "password"
                        },
                        new
                        {
                            Id = 4,
                            Biography = "Author Four Biography",
                            Email = "AuthorFour@exmaple.com",
                            Name = "Author Four",
                            Password = "password"
                        },
                        new
                        {
                            Id = 5,
                            Biography = "Author Five Biography",
                            Email = "AuthorFive@exmaple.com",
                            Name = "Author Five",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            GenreId = 1,
                            Title = "The Great Gatsby",
                            Year = 1925
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            GenreId = 2,
                            Title = "To Kill a Mockingbird",
                            Year = 1960
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            GenreId = 3,
                            Title = "1984",
                            Year = 1949
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            GenreId = 4,
                            Title = "Pride and Prejudice",
                            Year = 1813
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            GenreId = 5,
                            Title = "The Catcher in the Rye",
                            Year = 1951
                        });
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.BorrowedBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(2679));

                    b.Property<string>("GenreSnapshot")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<bool>("IsReturned")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TitleSnapshot")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("YearSnapshot")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookDetailsId");

                    b.HasIndex("MemberId");

                    b.ToTable("BorrowedBooks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookDetailsId = 1,
                            BorrowDate = new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3712),
                            GenreSnapshot = "Fiction",
                            IsReturned = false,
                            MemberId = 1,
                            ReturnDate = new DateTime(2024, 10, 7, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3723),
                            TitleSnapshot = "The Great Gatsby",
                            YearSnapshot = 1925
                        },
                        new
                        {
                            Id = 2,
                            BookDetailsId = 2,
                            BorrowDate = new DateTime(2024, 9, 23, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3727),
                            GenreSnapshot = "Fiction",
                            IsReturned = false,
                            MemberId = 2,
                            ReturnDate = new DateTime(2024, 10, 7, 4, 34, 32, 618, DateTimeKind.Local).AddTicks(3730),
                            TitleSnapshot = "To Kill a Mockingbird",
                            YearSnapshot = 1960
                        });
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Art"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Gazetteers"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.LibraryBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("LibraryBooks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfMembership")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(1728));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MembershipDuration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfMembership = new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(2592),
                            Email = "johnDoe@example.com",
                            MembershipDuration = 30,
                            Name = "John Doe",
                            Password = "john123"
                        },
                        new
                        {
                            Id = 2,
                            DateOfMembership = new DateTime(2024, 9, 23, 4, 34, 32, 619, DateTimeKind.Local).AddTicks(2606),
                            Email = "janDoe@example.com",
                            MembershipDuration = 30,
                            Name = "Jane Doe",
                            Password = "jane123"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.Book", b =>
                {
                    b.HasOne("LibraryManagementSystemEF.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystemEF.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.BorrowedBook", b =>
                {
                    b.HasOne("LibraryManagementSystemEF.Entities.Book", "BookDetails")
                        .WithMany()
                        .HasForeignKey("BookDetailsId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("LibraryManagementSystemEF.Entities.Member", "Member")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookDetails");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.LibraryBook", b =>
                {
                    b.HasOne("LibraryManagementSystemEF.Entities.Book", "Book")
                        .WithOne()
                        .HasForeignKey("LibraryManagementSystemEF.Entities.LibraryBook", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagementSystemEF.Entities.Member", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
