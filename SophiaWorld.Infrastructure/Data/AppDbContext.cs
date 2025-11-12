using Microsoft.EntityFrameworkCore;
using SophiaWorld.Core.Entities;
using System.Collections.Generic;

namespace SophiaWorld.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Notice> Notices => Set<Notice>();
        public DbSet<BoardPost> BoardPosts => Set<BoardPost>();
        //public DbSet<Reservation> Reservations => Set<Reservation>();
    }
}