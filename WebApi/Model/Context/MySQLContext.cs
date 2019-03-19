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

        public DbSet<ActorMovie> ActorMovies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(c => new { c.ActorId, c.MovieId });
        }

        public DbSet<_vw_mc_ator> vw_mc_ator { get; set; }

        public DbSet<_vw_mc_filme_visto> vw_mc_filme_visto { get; set; }

        public DbSet<_vw_mc_filme_ver> vw_mc_filme_ver { get; set; }


    }
}
