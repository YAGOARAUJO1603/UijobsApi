using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIJobsAPI.Models
{

    public class Candidato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCandidato { get; set; }
/*
        [Required]
        public int idTokenFirebase { get; set; }
*/

        [Required]
        [MaxLength(60)]
        public string nome { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string email { get; set; }

        
        //public byte[] foto { get; set; }

        [Required]
        [MaxLength(100)]
        public string nomeMae { get; set; }
/*
        [ForeignKey("idCurriculo")]
        public int IdCurriculo { get; set; }

        public virtual Curriculo Curriculo { get; set; }*/
        

        /*public static implicit operator Candidato(void v)
        {
            throw new NotImplementedException();
        }*/

        /*
       [ForeignKey("idTokenFirebase")]
       public TokenFirebase TokenFirebase { get; set; }
*/
    }
}
