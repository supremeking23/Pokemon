using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pokemon.Models
{
    [Table("tblPokemons")]

    public class PokemonModel
    {
        [Required]
        [Display(Name = "Pokemon ID")]
        [Key]
        public int pokemon_id { get; set; }


        [Required]
        [Display(Name = "Pokemon Name")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Letters only")]
        public string pokemon_name { get; set; }

        [Required]
        [Display(Name = "Pokemon Type")]
        public string pokemon_type { get; set; }

        [Required]
        [Display(Name = "Pokemon Level")]
        public string pokemon_level { get; set; }

        [Required]
        [Display(Name = "Trainer ID")]
        public int trainer_id { get; set; }

    }


    public class PokemonContext : DbContext
    {
        public DbSet<PokemonModel> Pokemons { get; set; }
    }
}