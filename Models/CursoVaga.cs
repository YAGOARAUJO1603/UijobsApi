using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class CursoVaga
    {
        public Vaga idVaga { get; set; }
        public Curso idCurso { get; set; }
        public string idCursoVaga {get; set;}
    }
}