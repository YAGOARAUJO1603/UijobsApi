using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idVagas), nameof(idIdiomas))]
    public class VagaIdioma
    {
        [Required]
        public int idVagas { get; set; }
        
        [Required]
        public int idIdiomas { get; set; }

        [Required]
        public int idNivel { get; set; }

        [ForeignKey("idNivel")]
        public Nivel Nivel { get; set; }

        [ForeignKey("idVagas")]
        public Vaga Vagas { get; set; }

        [ForeignKey("idIdiomas")]
        public Idioma Idioma { get; set; }
    }
}
