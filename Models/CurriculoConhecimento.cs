using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idCurriculo),nameof(idConhecimentos))]
    public class CurriculoConhecimento
    {
        [Column(Order = 0)]
        [NotNull]
        public int idCurriculo { get; set; }

        [Column(Order = 1)]
        [NotNull]
        public int idConhecimentos { get; set; }

        [NotNull]
        public int idNivel { get; set; }

        [ForeignKey("idCurriculo")]
        public Curriculo Curriculo { get; set; }

        [ForeignKey("idConhecimentos")]
        public Conhecimento Conhecimentos { get; set; }

        [ForeignKey("idNivel")]
        public Nivel Nivel { get; set; }
    }
}
