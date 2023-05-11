using E72LET_HFT_2022232.Models;
using System.Linq;

namespace E72LET_HFT_2022232.Logic
{
    public interface IStudioLogic
    {
        void Create(Studio item);
        void Delete(int id);
        Studio Read(int id);
        IQueryable<Studio> ReadAll();
        void Update(Studio item);
    }
}