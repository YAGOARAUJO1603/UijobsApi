using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Nivel
    {
        [Key]
        public int idNivel { get; set; }

        public int idIdioma { get; set; }

        public int NiveisDisponiveis { get; set; }

    }
}