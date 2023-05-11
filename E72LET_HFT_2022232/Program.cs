using E72LET_HFT_2022232.Repository;
using System;
using System.Linq;

namespace E72LET_HFT_2022232
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameDbContext db = new GameDbContext();
            var games = db.Games.ToArray();
            ;
        }
    }
}
