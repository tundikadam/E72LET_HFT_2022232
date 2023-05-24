using E72LET_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Repository
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
            old.MinimalSystemRequirementsId =item.MinimalSystemRequirementsId;
            old.OperatingSystem = item.OperatingSystem;
            old.RAM_size = item.RAM_size;
            old.SSD_space = item.SSD_space;
            old.CPU_Brand = item.CPU_Brand;
            old.CPU_ClockSpeed = item.CPU_ClockSpeed;
            old.VGA_Brand = item.VGA_Brand;
            old.VGA_MemorySize = item.VGA_MemorySize;


            ctx.SaveChanges();

        }
    }
}
