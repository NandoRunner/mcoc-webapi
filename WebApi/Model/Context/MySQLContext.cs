﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<_vw_mc_ator> vw_mc_ator { get; set; }
        public DbSet<_vw_mc_diretor> vw_mc_diretor { get; set; }
        public DbSet<_vw_mc_filme_visto> vw_mc_filme_visto { get; set; }
        public DbSet<_vw_mc_filme_ver> vw_mc_filme_ver { get; set; }
        public DbSet<_vw_mc_genero> vw_mc_genero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .Property<long>("Id").HasColumnName("ato_ator_id");
            modelBuilder.Entity<Actor>()
                .Property<string>("Name").HasColumnName("ato_nome");

            modelBuilder.Entity<Genre>()
                .Property<long>("Id").HasColumnName("gen_genero_id");
            modelBuilder.Entity<Genre>()
                .Property<string>("Name").HasColumnName("gen_nome");

            modelBuilder.Entity<Director>()
                .Property<long>("Id").HasColumnName("dir_diretor_id");
            modelBuilder.Entity<Director>()
                .Property<string>("Name").HasColumnName("dir_nome");

            modelBuilder.Entity<_vw_mc_ator>()
                .Property<string>("Name").HasColumnName("Ator");
            modelBuilder.Entity<_vw_mc_diretor>()
                .Property<string>("Name").HasColumnName("Diretor");
            modelBuilder.Entity<_vw_mc_genero>()
                .Property<string>("Name").HasColumnName("Genero");



        }
    }
}
