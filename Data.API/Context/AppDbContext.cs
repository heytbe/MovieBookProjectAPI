using Entity.API.Entity;
using Entity.API.Entity.MovieEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Context
{
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieImages> MovieImages { get; set; }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
