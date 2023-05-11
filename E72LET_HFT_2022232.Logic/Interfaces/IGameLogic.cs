using E72LET_HFT_2022232.Models;
using System.Linq;

namespace E72LET_HFT_2022232.Logic
{
    public interface IGameLogic
    {
        double? ActivisionsGamePriceAverage();
        int? ContendoCount();
        int? CountOfWin98();
        void Create(Game item);
        void Delete(int id);
        int LibrediaAgeLimit();
        int NewestGame();
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);
    }
}