using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Conhecimento
    {
        [Key]
        public int ConhecimentoId  { get; set; }
        public string nomeConhecimento { get; set; }

    }
}