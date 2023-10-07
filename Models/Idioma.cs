using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    public class Idioma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idIdiomas { get; set; }

        [Required]
        public string nomeIdioma { get; set; }
    }
}
