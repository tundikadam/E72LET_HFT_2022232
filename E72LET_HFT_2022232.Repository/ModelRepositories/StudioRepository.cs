using E72LET_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Repository
{
    public class StudioRepository : Repository<Studio>, IRepository<Studio>
    {
        public StudioRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Studio Read(int id)
        {
            return ctx.Studios.FirstOrDefault(t=>t.StudioId==id );
        }

        public override void Update(Studio item)
        {
            var old = Read(item.StudioId);
            foreach (var prop in old.GetType().GetProperties())
            { prop.SetValue(old, prop.GetValue(item)); }
            ctx.SaveChanges();
        }
    }
}
