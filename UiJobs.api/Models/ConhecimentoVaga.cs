using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class ConhecimentoVaga
    {
        public int idVagas { get; set; }
        
        public int idConhecimento { get; set; }
        public string idNivel { get; set; }
    }
}