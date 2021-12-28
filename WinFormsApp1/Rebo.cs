using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    public class Repo : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Clinic.db");
        }


        public DbSet<user> user { get; set; }
        public DbSet<patient> patient { get; set; }
        public DbSet<booking> booking { get; set; }

        public DbSet<prescribe_1> prescribes { get; set; }
    }
}
