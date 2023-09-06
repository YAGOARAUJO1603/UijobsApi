using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCurso { get; set; }

        [Required]
        public String nomeCurso { get; set; }

        [Required]
        [MaxLength(3)]
        public string diplomaCurso { get; set; }

    }
}
