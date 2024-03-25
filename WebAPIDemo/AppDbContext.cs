// using WebAPIDemo.Models;
// using Microsoft.EntityFrameworkCore;
//
// namespace WebAPIDemo;
//
// public class AppDbContext : DbContext
// {
//     public DbSet<Shirt> Shirts { get; set; }
//
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=db");
//     }
// }