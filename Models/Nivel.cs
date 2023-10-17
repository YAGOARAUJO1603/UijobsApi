using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    public class Nivel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idNivel { get; set; }

        //Isso afeta o banco
        [Required]
        public string niveisDisponiveis { get; set; }
    }
}
