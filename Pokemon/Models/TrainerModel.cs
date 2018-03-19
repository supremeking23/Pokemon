using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pokemon.Models
{
    [Table("tblTrainers")]
    public class TrainerModel
    {

        [Required]
        [Display(Name="Trainer ID")]
        [Key]
        public int trainer_id { get; set; }


        [Required]
        [Display(Name = "Trainer Name")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Letters only")]
        public string trainer_name { get; set; }

        [Required]
        [Display(Name = "Trainer Age")]
        public int trainer_age { get; set; }

        [Required]
        [Display(Name = "Trainer Address")]
        public string address { get; set; }
    }


    public class TrainerContext : DbContext
    {
        public DbSet<TrainerModel> Trainers { get; set; }
    }



}