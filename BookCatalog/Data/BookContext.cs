using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
namespace BookCatalog.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> books { get; set; }
        public object Books { get; internal set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=p511-890");
        }
    }
}
