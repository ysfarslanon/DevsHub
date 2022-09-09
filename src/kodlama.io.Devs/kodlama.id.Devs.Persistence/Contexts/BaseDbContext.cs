using kodlama.io.Devs.Domain.Entities;
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
        public DbSet<Technology> Technologies { get; set; }

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
                pl.Property(p => p.Name).HasColumnName("Name");

                pl.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(tech =>
            {
                tech.ToTable("Technologies").HasKey("Id");
                tech.Property(p => p.Id).HasColumnName("Id");
                tech.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                tech.Property(p => p.Name).HasColumnName("Name");

                tech.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingLanguage[] languages = { new(1, "C#"), new(2, "Java"), new(3, "Go"), new(4, "Pyton"), new(5, "JavaScript") };

            modelBuilder.Entity<ProgrammingLanguage>().HasData(languages);

            Technology[] technologies = { new(1, 1, "ASP.NET"), new(2, 1, "WPF"), new(3, 2, "Spring"), new(4, 2, "JSP"), new(5, 4, "Flask"), new(6, 5, "Angular"), new(7, 5, "React"), new(8, 5, "Vue") };

            modelBuilder.Entity<Technology>().HasData(technologies);
        }
    }
}
