using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<DSUser> DSUser { get; set; }
        public virtual DbSet<DSBuilding> DSBuilding { get; set; }
        public virtual DbSet<DSMonitor> DSMonitor { get; set; }
        public virtual DbSet<DSMedia> DSMedia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }


}

