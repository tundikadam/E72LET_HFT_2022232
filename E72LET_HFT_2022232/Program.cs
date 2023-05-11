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
            GameDbContext db = new GameDbContext();
            //  var games = db.Games.ToArray();
            // var studios = db.Studios.ToArray();
            //var minimalsystem = db.MinimalSystemRequirements.ToArray();
            IRepository<Studio> repository = new StudioRepository(db);
            Studio s = new Studio(100, "AdamSoft");
            repository.Create(s);
            repository.Delete(100);
            var items = repository.ReadAll().ToArray();
            ;
            ;
        }
    }
}
