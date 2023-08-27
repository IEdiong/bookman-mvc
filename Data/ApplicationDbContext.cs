using Bookman.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookman.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                Name = "Basics of C# Language",
                Author = "Vnicom Hub",
                Description = "This book covers the basics of C#.",
                Price = 5000,
                Year = 2021,
                CreatedAt = DateTime.Now.AddDays(-200),
                UpdatedAt = DateTime.Now.AddDays(-200)
            },
            new Book
            {
                Id = 2,
                Name = "Fuji Music",
                Author = "Ade Ogunsanya",
                Description = "Want to learn how to sing fuji jazz, then this book is for you.",
                Price = 2000,
                Year = 1998,
                CreatedAt = DateTime.Now.AddDays(-3),
                UpdatedAt = DateTime.Now.AddDays(-3)
            },
            new Book
            {
                Id = 3,
                Name = "Introduction to Backend development in C#",
                Author = "Ediong Joseph",
                Description = "This book helps you master the basics of backend development with the C# language.",
                Price = 10000,
                Year = 2023,
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now.AddDays(-10)
            },
            new Book
            {
                Id = 4,
                Name = "Introduction to Frontend development with Angular",
                Author = "Ediong Joseph",
                Description = "This book helps you master the basics of frontend developement with Angular.",
                Price = 10500,
                Year = 2023,
                CreatedAt = DateTime.Now.AddDays(-50),
                UpdatedAt = DateTime.Now.AddDays(-50)
            }
        };
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd(); // Configuring the property as required
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.Year).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();

            // Add data using HasData inside entity configuration
            entity.HasData(books);
        });
        base.OnModelCreating(modelBuilder);
    }
}

