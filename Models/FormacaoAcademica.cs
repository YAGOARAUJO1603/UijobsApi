using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class FormacaoAcademica
    {
        [Key]
        public int idFormacaoAcademica { get; set; }

        public Graduacao IdGraduacao {get; set;}   

        public Curso idCurso { get; set; }
        
        public string idiomas { get; set; }
    }
}