using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idVagas), nameof(idConhecimentos))]
    public class VagaConhecimento
    {
        [Required]
        public int idVagas { get; set; }

        [Required]
        public int idConhecimentos { get; set; }

        [Required]
        public int idNivel { get; set; }

        [ForeignKey("idNivel")]
        public Nivel Nivel { get; set; }

        [ForeignKey("idVagas")]
        public Vaga Vagas { get; set; }

        [ForeignKey("idConhecimentos")]
        public Conhecimento Conhecimentos { get; set; }
    }
}
