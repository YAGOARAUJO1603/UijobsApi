using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIJobsAPI.Models
{
    public class Curriculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCurriculo { get; set; }
        
        //Novo
        [Required]
        public int idEscolaridade { get; set; }

        //Novo
        [Required]
        public int idCandidato { get; set; }

        [Required]
        [MaxLength(200)]
        public string objetivo { get; set; }

        //Novo
        //Data de Cadastro do Curriculo
        [Required]
        public DateTime dcCurriculo { get; set; }
        
        //Novo
        //Data de ??? do Curriculo (Algo haver com ultima atualização no currículo)
        [Required]
        public DateTime duCurriculo { get; set; }

        [NotMapped]
        [ForeignKey("idEscolaridade")]
        public Escolaridade Escolaridade { get; set; }

        [ForeignKey("idCandidato")]
        public Candidato Candidato { get; set; }
    }
}
