using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Curso
    {
        [Key]
        public int idCurso { get; set; }
        public string nomeCurso { get; set; }
    }
}