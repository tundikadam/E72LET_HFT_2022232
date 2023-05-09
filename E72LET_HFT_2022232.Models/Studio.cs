using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_2022232.Models
{
    public class Studio
    {
        public Studio(int studioId, int studioName)
        {
            StudioId = studioId;
            StudioName = studioName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
      public  int StudioId { get; set; }
        [StringLength(50)]
       public int StudioName { get; set; }
        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }

    }
}

