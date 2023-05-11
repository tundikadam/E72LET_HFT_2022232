using E72LET_HFT_2022232.Models;
using System.Linq;

namespace E72LET_HFT_2022232.Logic
{
    public interface IMinimalSystemRequriementsLogic
    {
        void Create(MinimalSystemRequirements item);
        void Delete(int id);
        MinimalSystemRequirements Read(int id);
        IQueryable<MinimalSystemRequirements> ReadAll();
        void Update(MinimalSystemRequirements item);
    }
}