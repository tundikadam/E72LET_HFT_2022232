using E72LET_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace E72LET_HFT_2022232.Repository
{
    public class GameDbContext:DbContext
    {  public DbSet<Games> Games { get; set; }
        public DbSet<MinimalSystemRequirements> MinimalSystemRequirements { get; set; }
       public GameDbContext()
        { Database.EnsureCreated(); }



    }
}
