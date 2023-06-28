using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurs.Model
{
    public class ModelContext:DbContext
    {
        public DbSet<Buyer> Buyer { get; set; } = null;
        public DbSet<RealEstate> RealEstate { get; set; } = null;
        public DbSet<Realtor> Realtor { get; set; }=null;
        public DbSet<SalesMan> SalesMan { get; set; } = null;
        public DbSet<Sale> Sale { get; set; } = null;
        public DbSet<User> User { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RealEstate.db");
        }
    }
}
