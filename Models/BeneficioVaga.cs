using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class BeneficioVaga
    {
        [Key]
        public Beneficio idBeneficio { get; set; }
        public string idVaga { get; set; }
    }
}