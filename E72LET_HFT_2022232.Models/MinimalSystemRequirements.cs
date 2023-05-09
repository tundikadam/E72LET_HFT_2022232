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
        public MinimalSystemRequirements( int minrequirementId,string operatingSystem, double rAM_size, double sSD_space, string cPU_Brand, double cPU_ClockSpeed, string vGA_Brand, int vGA_MemorySize)
        {
            MinimalSystemRequirementsId = minrequirementId;
            OperatingSystem = operatingSystem;
            RAM_size = rAM_size;
            SSD_space = sSD_space;
            CPU_Brand = cPU_Brand;
            CPU_ClockSpeed = cPU_ClockSpeed;
            VGA_Brand = vGA_Brand;
            VGA_MemorySize = vGA_MemorySize;
         
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     public    int MinimalSystemRequirementsId { get; set; }
        [StringLength(50)]
    public    string OperatingSystem { get; set; }

        [Range(1, 32768)]

        //A méret MB-ban értendő
    public    double RAM_size { get; set; }

        [Range(1, 200)]
        //A méret GB-ban értendő

     public   double SSD_space { get; set; }
        [StringLength( 50)]
     public   string CPU_Brand { get; set; }

        //A CPU órajele Gigahertzben értendő
        [Range(1,5)]
   public     double CPU_ClockSpeed{get;set;}
        [StringLength(50)]
     public   string VGA_Brand { get; set; }
        [Range(0,16384)]

        //A VGA memória mérete MB-ban értendő
     public  int VGA_MemorySize { get; set; }
     
        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }
       

    }
}
