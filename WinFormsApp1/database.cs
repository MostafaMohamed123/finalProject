using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class DataBaseContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=ClinicDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<user>().HasData(new user
            {
                id = "1",
                name = "mostafa",
                password = "12345"

            });
        }

        public DbSet<user> user { get; set; }
        public DbSet<patient> patient { get; set; }
        public DbSet<booking> booking { get; set; }

        public DbSet<prescribe_1> prescribes { get; set; }

    }
}
