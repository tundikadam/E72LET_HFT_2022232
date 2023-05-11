using E72LET_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Repository.ModelRepositories
{
    public class MinimalSystemRequiresRepository : Repository<MinimalSystemRequirements>, IRepository<MinimalSystemRequirements>
    {
        public MinimalSystemRequiresRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override MinimalSystemRequirements Read(int id)
        {
            return ctx.MinimalSystemRequirements.FirstOrDefault(t => t.MinimalSystemRequirementsId == id);
        }

        public override void Update(MinimalSystemRequirements item)
        {
            var old = Read(item.MinimalSystemRequirementsId);
            foreach (var prop in old.GetType().GetProperties())
            { prop.SetValue(old, prop.GetValue(item)); }
            ctx.SaveChanges();

        }
    }
}
