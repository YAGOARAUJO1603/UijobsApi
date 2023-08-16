using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Curriculo
    {
        [Key]
        public int CurriculoId {get; set;}
        public string Objetivo { get; set; }
        public Conhecimento ConhecimentoId { get; set; }
        public FormacaoAcademica idFormacaoAcademica { get; set; }
        public CarreiraProfissional idCarreiraProfissional { get; set; }
        
        
    }
}