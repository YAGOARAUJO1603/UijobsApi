using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idConhecimentos))]
    [Index(nameof(idNivel))]
    public class Conhecimento
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idConhecimentos { get; set; }
        [Required]
        public int idNivel { get; set; }
        [Required]
        public ConhecimentoEnum nomeConhecimento { get; set; }

        [ForeignKey("idNivel")]
        public Nivel Nivel { get; set; }
    }
}
