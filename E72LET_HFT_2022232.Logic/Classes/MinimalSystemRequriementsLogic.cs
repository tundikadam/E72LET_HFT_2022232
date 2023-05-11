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

        public MinimalSystemRequriementsLogic(IRepository<MinimalSystemRequirements> repo)
        {
            this.repo = repo;
        }

        public void Create(MinimalSystemRequirements item)
        {
            if (item.OperatingSystem.Length<3)
            { throw new ArgumentException("The operating system's name is too short"); }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public MinimalSystemRequirements Read(int id)
        {
            var minimal = this.repo.Read(id);
            if (minimal == null)
            { throw new ArgumentException("This system requriement not exists"); }
            return minimal;
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
