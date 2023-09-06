using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idCurriculo),nameof(idConhecimentos))]
    public class CurriculoConhecimento
    {
        [Column(Order = 0)]
        public int idCurriculo { get; set; }

        [Column(Order = 1)]
        public int idConhecimentos { get; set; }

        [ForeignKey("idCurriculo")]
        public Curriculo Curriculo { get; set; }

        [ForeignKey("idConhecimentos")]
        public Conhecimento Conhecimentos { get; set; }
    }
}
