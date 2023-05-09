using E72LET_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace E72LET_HFT_2022232.Repository
{
    public class GameDbContext : DbContext
    {
        public DbSet<Games> Games { get; set; }
        public DbSet<MinimalSystemRequirements> MinimalSystemRequirements { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public GameDbContext()
        { Database.EnsureCreated(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =G:\Egyetem\4\Haladó fejlesztési technikák\Féléves\Feladat\E72LET_HFT_2022232\E72LET_HFT_2022232.Repository\games.mdf; Integrated Security = True;MultipleActiveResultSets=True";
                optionsBuilder.UseSqlServer
                    (conn).UseLazyLoadingProxies();
            }
           



    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//Games minimális rendszerigény közti kapcsolat

            modelBuilder.Entity<Games>().HasOne(t => t.Minimal).WithMany(t => t.Games).HasForeignKey(t => t.MinimalSystemRequirementsId).OnDelete(DeleteBehavior.Cascade);
            //Games studio tábla közötti kapcsolat
            modelBuilder.Entity<Games>().HasOne(t => t.Studio).WithMany(t => t.Games).HasForeignKey(t=>t.StudioId).OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
