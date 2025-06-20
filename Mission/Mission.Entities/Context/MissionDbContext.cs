﻿using Mission.Entities;
using Microsoft.EntityFrameworkCore;
using Mission.Entities.Entities;

namespace Mission.Entities.Context
{
    public class MissionDbContext(DbContextOptions<MissionDbContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<MissionTheme> MissionThemes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "admin",
                LastName = "Admin",
                EmailAddress = "admin@email.com",
                UserType = "admin",
                Password = "admin@123",
                PhoneNumber = "9876543210",
                CreatedDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            base.OnModelCreating(builder);
        }
    }
}
