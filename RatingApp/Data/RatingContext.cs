using Microsoft.EntityFrameworkCore;
using RatingApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace RatingApp.Data
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options) : base(options)
        {
        }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.StudentId, r.Subject })
                .IsUnique();
        }
    }
}
