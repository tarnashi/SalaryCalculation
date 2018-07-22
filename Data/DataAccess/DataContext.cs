﻿using System.Data.Entity;
using Data.Models;

namespace Data.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
