using Castle.DynamicProxy.Generators.Emitters;
using E72LET_HFT_2022232.Models;
using E72LET_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Logic
{
    public class StudioLogic : IStudioLogic
    {
        IRepository<Studio> repo;

        public StudioLogic(IRepository<Studio> repo)
        {
            this.repo = repo;
        }

        public void Create(Studio item)
        {
            if (item.StudioName.Length < 5)
            { throw new ArgumentException("The studio's name is too short"); }

            this.repo.Create(item);

        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Studio Read(int id)
        {
            var studio = this.repo.Read(id);
            if(studio==null)
            { throw new ArgumentException("This studio dowsn't exist"); }
            return studio;
        }

        public IQueryable<Studio> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Studio item)
        {
            this.repo.Update(item);
        }
    }
}
