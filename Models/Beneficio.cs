﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    public class Beneficio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idBeneficio { get; set; }

        [Required]
        public BeneficioEnum nomeBeneficio { get; set; }
    }
}
