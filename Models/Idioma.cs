using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    [Index(nameof(idNivel))]
    public class Idioma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idIdiomas { get; set; }

        [Required]
        public int idNivel { get; set; }

        [Required]
        public IdiomaEnum nomeIdioma { get; set; }

        [ForeignKey("idNivel")]
        public Nivel Nivel { get; set; }
    }
}
