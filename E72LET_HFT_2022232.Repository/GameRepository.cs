using E72LET_HFT_2022232.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Repository
{
    public class GameRepository : Repository<Game>, IRepository<Game>
    {
        public GameRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Game Read(int id)
        {
            return ctx.Games.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Game item)
        {
            var old = Read(item.Id);
            foreach(var prop in old.GetType().GetProperties())
            { prop.SetValue(old, prop.GetValue(item)); }
            ctx.SaveChanges();
        }
    }
}
