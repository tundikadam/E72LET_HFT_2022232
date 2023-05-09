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
                new Game(4 ,3,3,"Skycraper Simulator",3,3),
               new Game(5,4,4,"Call of Duty 1",16,10),
               new Game(6,4,5,"Call of Duty 4",16,10),
                 new Game(7,4,5,"Call of Duty World at War",18,15),
                 new Game(8,4,6,"Call of Duty Black Ops 3",18,15),
                 new Game(9,4,7,"Call of Duty Wolrd at War 2",18,20),
                 new Game(10,5,8,"Grand Theft Auto San Andreas",18,63),
                 new Game(11,5,9,"Grand Theft Auto 4",18,20),
                });
            modelBuilder.Entity<MinimalSystemRequirements>().HasData(new MinimalSystemRequirements[]
                {new MinimalSystemRequirements(1,"Windows Xp",2048,1.5,"Intel Core 2 Duo",2.4,"Nvidia GeForce GTS 450",1024),
              new MinimalSystemRequirements(2,"Windows 98",256,0.3,"Intel Pentium 3",1,"Nvidia GeForce 4 Ti",128),
              new MinimalSystemRequirements(3,"Windows Xp",512,1,"Intel Pentium 4",1.5,"Nvidia GeForce 6800",128),
              new MinimalSystemRequirements(4,"Windows 98",128,1.4,"Intel Pentium 3",0.6,"Nvidia Geforce 256",32),
              new MinimalSystemRequirements(5,"Windows Xp",512,8,"Intel Pentium 4",2.4,"Nvidia GeForce 6600",256),
              new MinimalSystemRequirements(6,"Windows 7",6144,100,"Intel Core I3-530",2.93,"Nvidia GeForce GTX 470",1024),
              new MinimalSystemRequirements(7,"Windows 7",8192,90,"Intel Core I3-3225",3.3,"Nvidia GeForce GTX 660",2048),
              new MinimalSystemRequirements(8,"Windows 2000",256,3.6,"Intel Pentium 3",1,"Nvidia GeForce 3",256),
              new MinimalSystemRequirements(9,"Windows Xp",1536,16,"Intel Core 2 Duo",1.8,"Nvidia GeForce GTS 7900",256),
              
                });
            modelBuilder.Entity<Studio>().HasData(new Studio[]
                {new Studio(1,"SCS Software"),
                new Studio(2,"Contendo media"),
                new Studio(3,"Libredia"),
                new Studio(4,"SCS Software"),
                new Studio(1,"SCS Software"),

                }) ;
        }
    }
}
