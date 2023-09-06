using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idConhecimentos))]
    [Index(nameof(idNivel))]
    public class Conhecimentos
    {
        public int idConhecimentos { get; set; }
        [ForeignKey(nameof(idNivel))]
        public Nivel idNivel { get; set; }
        public ConhecimentoEnum nomeConhecimento { get; set; }
    }
}
