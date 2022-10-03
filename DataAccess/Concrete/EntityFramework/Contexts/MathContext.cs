using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MathContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=MathDb;Username=postgres;Password=1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new OperationClaimMapping());
            modelBuilder.ApplyConfiguration(new UserOperationClaimMapping());
            modelBuilder.ApplyConfiguration(new ContentMapping());
            modelBuilder.ApplyConfiguration(new SubjectMapping());
            modelBuilder.ApplyConfiguration(new ForumMapping());
            modelBuilder.ApplyConfiguration(new DiscussionMapping());
            modelBuilder.ApplyConfiguration(new TagMapping());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
