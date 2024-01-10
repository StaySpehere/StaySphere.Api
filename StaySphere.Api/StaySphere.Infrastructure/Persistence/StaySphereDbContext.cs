using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence
{
    public class StaySphereDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public StaySphereDbContext(DbContextOptions<StaySphereDbContext> options)
           : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}