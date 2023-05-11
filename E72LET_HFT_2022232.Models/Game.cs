using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E72LET_HFT_2022232.Models
{
    public class Game
    {
        public Game(int id, int studioId, int minimalSystemRequirementsId, string name, int age_Limit, int price,int appearance)
        {
            Id = id;
            StudioId = studioId;
            MinimalSystemRequirementsId = minimalSystemRequirementsId;
            Name = name;
            Age_Limit = age_Limit;
            Price = price;
            Appearance = appearance;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StudioId { get; set; }
        public int MinimalSystemRequirementsId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Range(0,18)]
        public int Age_Limit { get; set; }
        [Range(1990,2023)]
        
        public int Appearance { get; set; }


        //Az ár euróban értendő
        [Range(0, 100)]
        public int Price { get; set; }
        [NotMapped]
        public virtual MinimalSystemRequirements Minimal { get; set; }
        [NotMapped]
        public virtual Studio Studio { get; set; }

    


    }
}
