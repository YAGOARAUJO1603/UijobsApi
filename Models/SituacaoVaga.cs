using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class SituacaoVaga
    {
        [Key]
        public int idSituacao { get; set; }
        public string descricaoSituacao { get; set; }
    }
}