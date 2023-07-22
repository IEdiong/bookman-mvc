using Bookman.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookman.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Book> Books { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Book> books = new()
        {
            new Book("Basics of C# Language")
            {
                Id = 1,
                Author = "Vnicom Hub",
                Description = "This book covers the basics of C#.",
                Price = 5000,
                Year = 2021
            },
            new Book("Fuji Music")
            {
                Id = 2,
                Author = "Ade Ogunsanya",
                Description = "Want to learn how to sing fuji jazz, then this book is for you.",
                Price = 2000,
                Year = 1998
            },
            new Book("Introduction to Backend development in C#")
            {
                Id = 3,
                Author = "Ediong Joseph",
                Description = "This book helps you master the basics of backend development with the C# language.",
                Price = 10000,
                Year = 2023
            },
            new Book("Introduction to Frontend development with Angular")
            {
                Id = 4,
                Author = "Ediong Joseph",
                Description = "This book helps you master the basics of frontend developement with Angular.",
                Price = 10500,
                Year = 2023
            }
        };
        modelBuilder.Entity<Book>().HasData(books);
        base.OnModelCreating(modelBuilder);
    }
}

