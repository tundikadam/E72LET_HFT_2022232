using E72LET_HFT_2022232.Models;
using E72LET_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Logic
{
    internal class MinimalSystemRequriementsLogic : IMinimalSystemRequriementsLogic
    {
        IRepository<MinimalSystemRequirements> repo;
        public void Create(MinimalSystemRequirements item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public MinimalSystemRequirements Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<MinimalSystemRequirements> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(MinimalSystemRequirements item)
        {
            repo.Update(item);
        }
    }
}
