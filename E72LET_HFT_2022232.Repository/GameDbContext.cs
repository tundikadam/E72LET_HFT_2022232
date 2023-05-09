using E72LET_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace E72LET_HFT_2022232.Repository
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
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

            modelBuilder.Entity<Game>().HasOne(t => t.Minimal).WithMany(t => t.Games).HasForeignKey(t => t.MinimalSystemRequirementsId).OnDelete(DeleteBehavior.Cascade);
            //Games studio tábla közötti kapcsolat
            modelBuilder.Entity<Game>().HasOne(t => t.Studio).WithMany(t => t.Games).HasForeignKey(t => t.StudioId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Game>().HasData(new Game[]
                {new Game(1,1,1,"Scania Truck Driving Simulator",3,10),
                new Game(2,1,2,"Bus Driver",3,18),
                new Game(3,2,3,"Bus Simulator",3,10),
                new Game(4 ,3,3,"Sycraper Simulator",3,3),
               
                });
        }
    }
}
