using Microsoft.EntityFrameworkCore;
using MSSAMentorshipCompanionWebAPI.Models;
using System.Reflection.Metadata;

namespace MSSAMentorshipCompanionWebAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<UserCredentials> UserCredentials { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Mentorship> Mentorships { get; set; }
        public DbSet<ChatThread> ChatThreads { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Goal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCredentials>()
                .HasOne(e => e.UserProfile)
                .WithOne(e => e.UserCredentials)
                .HasForeignKey<UserProfile>();
        }
    }
}
