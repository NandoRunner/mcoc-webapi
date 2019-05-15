using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<MccAlliance> MccAlliances { get; set; }
        public DbSet<MccHeroe> MccHeroes { get; set; }
        public DbSet<MccSynergy> MccSynergys { get; set; }
        public DbSet<MccUser> MccUsers { get; set; }
        public DbSet<MccUserAlliance> MccUserAlliances { get; set; }

        //public DbSet<_vw_mc_filme_visto> vw_mc_filme_visto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MccUserAlliance>()
                .Property<long>("id_a").HasColumnName("user_id");
            modelBuilder.Entity<MccUserAlliance>()
                .Property<long>("id_b").HasColumnName("alliance_id");

            modelBuilder.Entity<MccHeroe>()
                .Property<int>("heroe_class").HasColumnName("class");

            modelBuilder.Entity<MccUserAlliance>()
               .HasKey(c => new { c.id_a, c.id_b });

        }
    }
}
