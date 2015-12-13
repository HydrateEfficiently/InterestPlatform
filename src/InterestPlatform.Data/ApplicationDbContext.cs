using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Interests;
using InterestPlatform.Data.Posts;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Interest> Interests { get; set; }

        public DbSet<ContinuousFilter> ContinuousFilters { get; set; }

        public DbSet<DiscreteFilter> DiscreteFilters { get; set; }

        public DbSet<SwitchFilter> SwitchFilters { get; set; }

        public DbSet<DiscreteFilterOption> DiscreteFilterOptions { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Post> Posts { get; set; }
        
        public DbSet<ContinuousFilterField> ContinuousFilterFields { get; set; }

        public DbSet<DiscreteFilterField> DiscreteFilterFields { get; set; }

        public DbSet<SwitchFilterField> SwitchFilterFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Interest>(b => b.HasAnnotation("Relational:TableName", "Interests"));
            modelBuilder.Entity<ContinuousFilter>(b => b.HasAnnotation("Relational:TableName", "ContinuousFilters"));
            modelBuilder.Entity<DiscreteFilter>(b => b.HasAnnotation("Relational:TableName", "DiscreteFilters"));
            modelBuilder.Entity<SwitchFilter>(b => b.HasAnnotation("Relational:TableName", "SwitchFilters"));
            modelBuilder.Entity<DiscreteFilterOption>(b => b.HasAnnotation("Relational:TableName", "DiscreteFilterOptions"));
            modelBuilder.Entity<Subscription>(b => b.HasAnnotation("Relational:TableName", "Subscriptions"));
            modelBuilder.Entity<Post>(b => b.HasAnnotation("Relational:TableName", "Posts"));
            modelBuilder.Entity<ContinuousFilterField>(b => b.HasAnnotation("Relational:TableName", "ContinuousFilterFields"));
            modelBuilder.Entity<DiscreteFilterField>(b => b.HasAnnotation("Relational:TableName", "DiscreteFilterFields"));
            modelBuilder.Entity<SwitchFilterField>(b => b.HasAnnotation("Relational:TableName", "SwitchFilterFields"));
        }
    }
}
