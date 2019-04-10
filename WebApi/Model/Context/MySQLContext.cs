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

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MccAlliance> MccAlliances { get; set; }
        public DbSet<MccUser> MccUsers { get; set; }

        public DbSet<MccUserAlliance> MccUserAlliances { get; set; }

        public DbSet<_vw_mc_ator> vw_mc_ator { get; set; }
        public DbSet<_vw_mc_diretor> vw_mc_diretor { get; set; }
        public DbSet<_vw_mc_filme_visto> vw_mc_filme_visto { get; set; }
        public DbSet<_vw_mc_filme_ver> vw_mc_filme_ver { get; set; }
        public DbSet<_vw_mc_genero> vw_mc_genero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MccUserAlliance>()
                .Property<long>("id_a").HasColumnName("user_id");
            modelBuilder.Entity<MccUserAlliance>()
                .Property<long>("id_b").HasColumnName("alliance_id");

            modelBuilder.Entity<MccUserAlliance>()
               .HasKey(c => new { c.id_a, c.id_b });

            modelBuilder.Entity<Actor>()
                .Property<long?>("id").HasColumnName("ato_ator_id");
            modelBuilder.Entity<Actor>()
                .Property<string>("name").HasColumnName("ato_nome");

            modelBuilder.Entity<Genre>()
                .Property<long?>("id").HasColumnName("gen_genero_id");
            modelBuilder.Entity<Genre>()
                .Property<string>("name").HasColumnName("gen_nome");

            modelBuilder.Entity<Director>()
                .Property<long?>("id").HasColumnName("dir_diretor_id");
            modelBuilder.Entity<Director>()
                .Property<string>("name").HasColumnName("dir_nome");

            modelBuilder.Entity<_vw_mc_ator>()
                .Property<string>("name").HasColumnName("Ator");
            modelBuilder.Entity<_vw_mc_diretor>()
                .Property<string>("name").HasColumnName("Diretor");
            modelBuilder.Entity<_vw_mc_genero>()
                .Property<string>("name").HasColumnName("Genero");



        }
    }
}
