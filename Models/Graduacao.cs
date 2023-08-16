using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Graduacao
    {
        [Key]
        public int idGraduacao { get; set; }
        public string nomeGraduacao { get; set; }
        public string inicioGraduacao { get; set; }
        public string fimGraduacao { get; set; }
    }
}