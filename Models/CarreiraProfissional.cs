using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class CarreiraProfissional
    {
        [Key]
        public int idCarreiraProfissional { get; set; }
        public string nomeEmpresa { get; set; }
        public string tempo { get; set; }
        public string cargo { get; set; }
    }
}