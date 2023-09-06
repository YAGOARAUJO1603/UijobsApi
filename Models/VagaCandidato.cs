using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idVagas), nameof(idCandidato))]

    public class VagaCandidato
    {
        [Column(Order = 0)]
        public int idVagas { get; set; }

        [Column(Order = 1)]
        public int idCandidato { get; set; }

        [ForeignKey("idVagas")]
        public Vaga Vagas { get; set; }

        [ForeignKey("idCandidato")]
        public Candidato Candidato { get; set; }
    
    }
}
