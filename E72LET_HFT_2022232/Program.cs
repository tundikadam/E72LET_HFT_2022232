using E72LET_HFT_2022232.Logic;
using E72LET_HFT_2022232.Models;
using E72LET_HFT_2022232.Repository;
using System;
using System.Linq;

namespace E72LET_HFT_2022232
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new GameDbContext();
            var repo = new GameRepository(ctx);
            var logic = new GameLogic(repo);
            
          
             



        }
    }
}
