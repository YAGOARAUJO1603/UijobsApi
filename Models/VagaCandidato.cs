using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idVagas), nameof(idCurriculo))]

    public class VagaCandidato
    {
        [Column(Order = 0)]
        [NotNull]
        public int idVagas { get; set; }

        //Arrumado
        [Column(Order = 1)]
        [NotNull]
        public int idCurriculo { get; set; }

        //Novo
        [NotNull]
        public DateTime dcCurriculo { get; set; }

        //Novo
        //
        [MaxLength(1)]
        [NotNull]
        public string vtEmpresa { get; set; }

        //Novo
        //
        [MaxLength(1)]
        [NotNull]
        public string vtCandidato { get; set; }

        [ForeignKey("idVagas")]
        [NotNull]
        public Vaga Vagas { get; set; }

        [ForeignKey("idCurriculo")]
        [NotNull]
        public Curriculo Curriculo { get; set; }
    
    }
}
