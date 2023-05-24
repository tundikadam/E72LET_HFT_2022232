using E72LET_HFT_2022232.Models;
using E72LET_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Logic
{
   public class MinimalSystemRequriementsLogic : IMinimalSystemRequriementsLogic
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
        {     this.repo.Delete(id); 
            
        }

        public MinimalSystemRequirements Read(int id)
        {
            var min = this.repo.Read(id);
            if(min==null)
            { throw new ArgumentException("This Requriements doesn't exist in this Database"); }
            return min;
           
           
        }

        public IQueryable<MinimalSystemRequirements> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(MinimalSystemRequirements item)
        {
            this.repo.Update(item);
        }
    }
}
