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

        public DbSet<HeroePerClass> vwHeroePerClass { get; set; }

        public DbSet<HeroePerHashtag> vwHeroePerHashtag { get; set; }


        public DbSet<HeroePerAbility> vwHeroePerAbility { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroePerClass>().Property<int>("id").HasColumnName("class");
            modelBuilder.Entity<HeroePerClass>().Property<string>("name").HasColumnName("class_name");

            modelBuilder.Entity<HeroePerClass>().HasKey(c => new { c.id });

            modelBuilder.Entity<HeroePerHashtag>().Property<int>("id").HasColumnName("hashtag_id");
            modelBuilder.Entity<HeroePerHashtag>().Property<string>("name").HasColumnName("hashtag_name");

            modelBuilder.Entity<HeroePerHashtag>().HasKey(c => new { c.id });


            modelBuilder.Entity<HeroePerAbility>().Property<int>("id").HasColumnName("ability_id");
            modelBuilder.Entity<HeroePerAbility>().Property<string>("name").HasColumnName("ability_name");
            modelBuilder.Entity<HeroePerAbility>().Property<int>("abilityType").HasColumnName("ability_type");

            modelBuilder.Entity<HeroePerAbility>().HasKey(c => new { c.id });


            modelBuilder.Entity<Heroe>()
                .Property<int>("heroeClass").HasColumnName("class");
            modelBuilder.Entity<Heroe>()
                .Property<string>("infoPage").HasColumnName("info_page");
            modelBuilder.Entity<Heroe>()
                .Property<DateTime?>("releaseDate").HasColumnName("release_date");

            modelBuilder.Entity<HeroeHashtag>()
                .Property<long>("idObjectA").HasColumnName("heroe_id");
            modelBuilder.Entity<HeroeHashtag>()
                .Property<long>("idObjectB").HasColumnName("hashtag_id");
            modelBuilder.Entity<HeroeHashtag>()
                .HasKey(c => new { c.idObjectA, c.idObjectB });

            modelBuilder.Entity<HeroeAbility>()
                .Property<long>("idObjectA").HasColumnName("heroe_id");
            modelBuilder.Entity<HeroeAbility>()
                .Property<long>("idObjectB").HasColumnName("ability_id");
            modelBuilder.Entity<HeroeAbility>()
                .HasKey(c => new { c.idObjectA, c.idObjectB });



            modelBuilder.Entity<UserAlliance>()
                .Property<long>("idObjectA").HasColumnName("user_id");
            modelBuilder.Entity<UserAlliance>()
                .Property<long>("idObjectB").HasColumnName("alliance_id");
            modelBuilder.Entity<UserAlliance>()
                .HasKey(c => new { c.idObjectA, c.idObjectB });


            modelBuilder.Entity<UserAlliance>()
                .Property<DateTime>("startDate").HasColumnName("start_date");
            modelBuilder.Entity<UserAlliance>()
                .Property<DateTime?>("endDate").HasColumnName("end_date");

            modelBuilder.Entity<UserHeroe>()
            .Property<long>("idObjectA").HasColumnName("user_id");
            modelBuilder.Entity<UserHeroe>()
                .Property<long>("idObjectB").HasColumnName("heroe_id");
            modelBuilder.Entity<UserHeroe>()
                .HasKey(c => new { c.idObjectA, c.idObjectB });

        }
    }
}
