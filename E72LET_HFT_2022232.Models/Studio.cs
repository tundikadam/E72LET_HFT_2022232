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
        public Studio(int studioId, string studioName)
        {
            StudioId = studioId;
            StudioName = studioName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
      public  int StudioId { get; set; }
        [StringLength(50)]
       public string StudioName { get; set; }
        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }

        public override bool Equals(object obj)
        {
            Studio s = obj as Studio;
            if (s == null)
            { return false; }
            else { return (this.StudioId == s.StudioId) && (this.StudioName == s.StudioName); }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.StudioId, this.StudioName);
        }
    }
}

