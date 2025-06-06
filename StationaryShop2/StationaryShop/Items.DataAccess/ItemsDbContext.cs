using Items.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.DataAccess
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 5,
                Name = "admin",
                Email = "admin@tatvasoft.com",
                Role = "admin",
                Password = "admin"
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
