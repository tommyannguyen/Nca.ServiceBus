﻿using Microsoft.EntityFrameworkCore;
using Multilingual.Repositories;

namespace Multilingual.MigrationTool
{
    public class AppDbContext : MultilingualDbContext
    {
        public AppDbContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=mysql-db;Database=testDb;User=root;Password=password123");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
