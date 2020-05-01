using Fox.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Xamarin.Forms;

namespace Fox.Repository
{ 
    public class DatabaseContext : DbContext
    {
        private readonly string _databaseName = "SqlDatabase.db";

        public DbSet<ItemDto> Items { get; set; }
        public DbSet<CartItemDto> CartItems { get; set; }
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ImageDto> Images { get; set; }

        public DatabaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = "";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", _databaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), _databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }

            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
