using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Models
{
    public class MinimalSystemRequirements
    {
        public MinimalSystemRequirements(int gameId, string operatingSystem, float rAM_size, int sSD_space, string cPU_Brand, float cPU_ClockSpeed, string vGA_Brand, float vGA_MemorySize, float vGA_ClockSpeed)
        {
            GameId = gameId;
            OperatingSystem = operatingSystem;
            RAM_size = rAM_size;
            SSD_space = sSD_space;
            CPU_Brand = cPU_Brand;
            CPU_ClockSpeed = cPU_ClockSpeed;
            VGA_Brand = vGA_Brand;
            VGA_MemorySize = vGA_MemorySize;
            VGA_ClockSpeed = vGA_ClockSpeed;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int GameId { get; set; }
        [StringLength(50)]
        string OperatingSystem { get; set; }
        [Range(1, 64)]
        float RAM_size { get; set; }

        [Range(1, 200)]
        //A méret GB-ban értendő

        int SSD_space { get; set; }
        [StringLength( 50)]
        string CPU_Brand { get; set; }

        //A CPU órajele Gigahertzben értendő
        [Range(1,5)]
        float CPU_ClockSpeed{get;set;}
        [StringLength(50)]
        string VGA_Brand { get; set; }
        [Range(0,32)]
        float VGA_MemorySize { get; set; }
        [Range(0,5)]
        float VGA_ClockSpeed { get; set; }
        [NotMapped]
        public virtual ICollection<Games> Games { get; set; }
       

    }
}
