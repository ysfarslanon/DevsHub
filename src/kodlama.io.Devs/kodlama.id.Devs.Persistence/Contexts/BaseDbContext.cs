using Core.Security.Entities;
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
        public DbSet<User> Users { get; set; }
        public DbSet<DeveloperUser> DeveloperUsers { get; set; }
        public DbSet<GithubProfile> GithubProfiles { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


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
                pl.ToTable("ProgrammingLanguages").HasKey("Id");
                pl.Property(p => p.Id).HasColumnName("Id");
                pl.Property(p => p.Name).HasColumnName("Name");

                pl.HasMany(p => p.Technologies);
            });
            ProgrammingLanguage[] languages = { new(1, "C#"), new(2, "Java"), new(3, "Go"), new(4, "Pyton"), new(5, "JavaScript") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(languages);

            modelBuilder.Entity<Technology>(tech =>
            {
                tech.ToTable("Technologies").HasKey("Id");
                tech.Property(p => p.Id).HasColumnName("Id");
                tech.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                tech.Property(p => p.Name).HasColumnName("Name");

                tech.HasOne(p => p.ProgrammingLanguage);
            });
            Technology[] technologies = { new(1, 1, "ASP.NET"), new(2, 1, "WPF"), new(3, 2, "Spring"), new(4, 2, "JSP"), new(5, 4, "Flask"), new(6, 5, "Angular"), new(7, 5, "React"), new(8, 5, "Vue") };
            modelBuilder.Entity<Technology>().HasData(technologies);

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users").HasKey("Id");
                user.Property(p => p.Id).HasColumnName("Id");
                user.Property(p => p.FirstName).HasColumnName("FirstName");
                user.Property(p => p.LastName).HasColumnName("LasName");
                user.Property(p => p.Email).HasColumnName("Email");
                user.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                user.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                user.Property(p => p.Status).HasColumnName("Status");
                user.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                user.HasMany(p => p.UserOperationClaims);
                user.HasMany(p => p.RefreshTokens);
            });

            modelBuilder.Entity<DeveloperUser>(devUser =>
            {
                devUser.ToTable("DeveloperUsers");

                devUser.HasOne(p => p.GithubProfile);
            });

            modelBuilder.Entity<GithubProfile>(github =>
            {
                github.ToTable("GithubProfiles").HasKey("Id");
                github.Property(p => p.Id).HasColumnName("Id");
                github.Property(p => p.URL).HasColumnName("URL");

                github.HasOne(p => p.DeveloperUser);
            });

            modelBuilder.Entity<OperationClaim>(operationClaim =>
            {
                operationClaim.ToTable("OperationClaims").HasKey("Id");
                operationClaim.Property(p => p.Id).HasColumnName("Id");
                operationClaim.Property(p=>p.Name).HasColumnName("Name");
            });
            OperationClaim[] operationClaims = { new(1, "Admin"), new(2, "User") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaims);

            modelBuilder.Entity<UserOperationClaim>(userOptClaim =>
            {
                userOptClaim.ToTable("UserOperationClaims").HasKey("Id");
                userOptClaim.Property(p => p.Id).HasColumnName("Id");

                userOptClaim.HasOne(p => p.User);
                userOptClaim.HasOne(p => p.OperationClaim);
            });

        }
    }
}
