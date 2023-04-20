using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E72LET_HFT_2022232.Models
{
    public class Games
    {
        public Games(string name, int age_Limit, int price, int id)
        {
            Name = name;
            Age_Limit = age_Limit;
            Price = price;
            Id = id;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Range(0,18)]
        public int Age_Limit { get; set; }


        //Az ár euróban értendő
        [Range(0, 100)]
        public int Price { get; set; }
        public virtual MinimalSystemRequirements Minimal { get; set; }
        public virtual Studio Studio { get; set; }

    


    }
}
