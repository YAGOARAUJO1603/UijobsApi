using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCursos { get; set; }

        [Required]
        public String nomeCurso { get; set; }

        [Required]
        [MaxLength(3)]
        public string DiplomaCurso { get; set; }

    }
}
