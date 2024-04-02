using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E72LET_HFT_2022232.Models
{
    public class Game
    {
        public Game(int id, int studioId, int minimalSystemRequirementsId, string name, int age_Limit, int appearance, int price)
        {
            Id = id;
            StudioId = studioId;
            MinimalSystemRequirementsId = minimalSystemRequirementsId;
            Name = name;
            Age_Limit = age_Limit;
            Appearance = appearance;
            Price = price;
        }
        public Game()
        { }
      

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
       // [NotMapped]
       // [JsonIgnore]
      //  public virtual MinimalSystemRequirements Minimal { get; set; }
      //  [NotMapped]
       // [JsonIgnore]
      //  public virtual Studio Studio { get; set; }

        public override bool Equals(object obj)
        {
            Game g = obj as Game;
            if(g==null)
            { return false; }
            else { return (this.Id == g.Id) &&( this.StudioId == g.StudioId) && (this.MinimalSystemRequirementsId == g.MinimalSystemRequirementsId )&& (this.Name == g.Name) && (this.Age_Limit == g.Age_Limit) && (this.Appearance == g.Appearance )&&( this.Price == g.Price); }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.StudioId, this.MinimalSystemRequirementsId, this.Name, this.Age_Limit, this.Appearance, this.Price);
;        }



    }
}
