using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Beneficio
    {
        [Key]
        public int idBeneficio { get; set; }
        public string nomeBeneficio { get; set; }
    }
}