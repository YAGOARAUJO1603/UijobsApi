using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Porte
    {
        [Key]
        public int idPorte { get; set; }
        public string descricao { get; set; }

    }
}