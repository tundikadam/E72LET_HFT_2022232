using E72LET_HFT_2022232.Models;
using E72LET_HFT_2022232.Repository;
using System;
using System.Linq;

namespace E72LET_HFT_2022232.Logic
{
    public class GameLogic : IGameLogic
    {
        IRepository<Game> repo;

        public GameLogic(IRepository<Game> repo)
        {
            this.repo = repo;
        }

        public void Create(Game item)
        {
            if (item.Name.Length < 5)
            { throw new ArgumentException("The game's name is too short"); }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game Read(int id)
        {
            var game = this.repo.Read(id);
            if (game == null)
            { throw new ArgumentException("Game not exists"); }
            return game;
        }

        public IQueryable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }
        //Az Activision által kiadott játékok átlagára
        public double? ActivisionsGamePriceAverage()
        { return this.repo.ReadAll().Where(t => t.Studio.StudioName == "Activison").Average(t => t.Price); }

        //A Contendo Media által kiadott játékok száma
        public int? ContendoCount()
        { return this.repo.ReadAll().Where(t => t.Studio.StudioName == "Contendo media").Count(); }
        //A Windows 98-on futó játékok száma
        public int? CountOfWin98()
        { return this.repo.ReadAll().Where(t => t.Minimal.OperatingSystem == "Windows 98").Count(); }

        //Legújabb játék kiadója
        public int NewestGame()
        { return this.repo.ReadAll().OrderByDescending(t => t.Appearance).First().Appearance; }
        //Mikor jelent meg az első, Rockstar Games által kiadott játék
        public int LibrediaAgeLimit()
        { return this.repo.ReadAll().Where(t => t.Studio.StudioName == "Rockstar Games").OrderBy(t => t.Appearance).First().Appearance; }
    }
}
