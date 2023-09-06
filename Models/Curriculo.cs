using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIJobsAPI.Models
{
    public class Curriculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCurriculo { get; set; }

        [Required]
        public int idFormacaoAcademica { get; set; }

        [Required]
        [MaxLength(200)]
        public string objetivo { get; set; }

        [ForeignKey("idFormacaoAcademica")]
        public FormacaoAcademica FormacaoAcademica { get; set; }
    }
}
