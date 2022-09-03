﻿using kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.id.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration;

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(pl =>
            {
                pl.ToTable("ProgrammingLanguage").HasKey("Id");
                pl.Property(p => p.Id).HasColumnName("Id");
                pl.Property(p=> p.Name).HasColumnName("Name");
            });

            ProgrammingLanguage[] languages = { new(1, "C#"), new(2, "Java"), new(3, "Go"), new(4, "Pyton"), new(5, "JavaScript") };

            modelBuilder.Entity<ProgrammingLanguage>().HasData(languages);
        }
    }
}