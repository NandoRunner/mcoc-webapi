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

        public DbSet<Ability> MccAbilitys { get; set; }
        public DbSet<Alliance> MccAlliances { get; set; }
        public DbSet<Hashtag> MccHashtags { get; set; }
        public DbSet<Heroe> MccHeroes { get; set; }
        public DbSet<HeroeAbility> MccHeroeAbilitys { get; set; }
        public DbSet<HeroeHashtag> MccHeroeHashtags { get; set; }
        public DbSet<Synergy> MccSynergys { get; set; }
        public DbSet<User> MccUsers { get; set; }
        public DbSet<UserAlliance> MccUserAlliances { get; set; }
        public DbSet<UserHeroe> MccUserHeroes { get; set; }

        public DbSet<WebUser> WebUsers { get; set; }

        public DbSet<FileRenamer> FileRenamers { get; set; }

        public DbSet<HeroePerClass> vwHeroePerClass { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroePerClass>()
                .Property<int>("name").HasColumnName("class");
            modelBuilder.Entity<HeroePerClass>()
            .HasKey(c => new { c.name });

            modelBuilder.Entity<Heroe>()
                .Property<int>("heroe_class").HasColumnName("class");

            modelBuilder.Entity<HeroeHashtag>()
                .Property<long>("id_a").HasColumnName("heroe_id");
            modelBuilder.Entity<HeroeHashtag>()
                .Property<long>("id_b").HasColumnName("hashtag_id");
            modelBuilder.Entity<HeroeHashtag>()
                .HasKey(c => new { c.id_a, c.id_b });

            modelBuilder.Entity<HeroeAbility>()
                .Property<long>("id_a").HasColumnName("heroe_id");
            modelBuilder.Entity<HeroeAbility>()
                .Property<long>("id_b").HasColumnName("ability_id");
            modelBuilder.Entity<HeroeAbility>()
                .HasKey(c => new { c.id_a, c.id_b });



            modelBuilder.Entity<UserAlliance>()
                .Property<long>("id_a").HasColumnName("user_id");
            modelBuilder.Entity<UserAlliance>()
                .Property<long>("id_b").HasColumnName("alliance_id");
            modelBuilder.Entity<UserAlliance>()
                .HasKey(c => new { c.id_a, c.id_b });


            modelBuilder.Entity<UserHeroe>()
            .Property<long>("id_a").HasColumnName("user_id");
            modelBuilder.Entity<UserHeroe>()
                .Property<long>("id_b").HasColumnName("heroe_id");
            modelBuilder.Entity<UserHeroe>()
                .HasKey(c => new { c.id_a, c.id_b });

        }
    }
}
