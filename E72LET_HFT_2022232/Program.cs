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
            var gamerepo = new GameRepository(ctx);
            var studiorepo = new StudioRepository(ctx);
            var minimalrepo = new MinimalSystemRequiresRepository(ctx); 
            var gamelogic = new GameLogic(gamerepo);
            var studiologic = new StudioLogic(studiorepo);
            var minimallogic = new MinimalSystemRequriementsLogic(minimalrepo);
           Console.WriteLine("Activison"+  gamelogic.ActivisionsGamePriceAverage());
            Console.WriteLine("Contendo"+gamelogic.ContendoCount());
            Console.WriteLine("Newest"+gamelogic.NewestGame());
            Console.WriteLine("Windows 98"+gamelogic.CountOfWin98());
            Console.WriteLine("Libredia"+gamelogic.LibrediaAgeLimit());
             



        }
    }
}
