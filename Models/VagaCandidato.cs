using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idVagas), nameof(idCurriculo))]

    public class VagaCandidato
    {
        [Column(Order = 0)]
        public int idVagas { get; set; }

        //Arrumado
        [Column(Order = 1)]
        public int idCurriculo { get; set; }

        //Novo
        public DateTime dcCurriculo { get; set; }

        //Novo
        //
        [MaxLength(1)]
        public string vtEmpresa { get; set; }

        //Novo
        //
        [MaxLength(1)]
        public string vtCandidato { get; set; }

        [ForeignKey("idVagas")]
        public Vaga Vagas { get; set; }

        [ForeignKey("idCurriculo")]
        public Curriculo Curriculo { get; set; }
    
    }
}
