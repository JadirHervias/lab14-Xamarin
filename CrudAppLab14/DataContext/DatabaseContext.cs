using CrudAppLab14.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CrudAppLab14.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Producto.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}
