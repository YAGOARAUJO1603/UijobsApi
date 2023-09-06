using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UIJobsAPI.Models
{
    public class FormacaoAcademica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idFormacaoAcademica { get; set; }

        [Required]
        public int idEscolaridade { get; set; }

        [Required]
        public int idCursos { get; set; }

        [ForeignKey("idCursos")]
        public Curso Curso { get; set; }

        [ForeignKey("idEscolaridade")]
        public Escolaridade Escolaridade { get; set; }
    }
}
