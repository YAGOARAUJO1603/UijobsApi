using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idEmpresa))]
    [Index(/*nameof(idTokenFirebase),*/nameof(idPortes))]
    public class Empresa
    {
        [NotNull]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idEmpresa { get; set; }
/*      
        [ForeignKey(nameof(idTokenFirebase))]
        [NotNull]
        [Required]
        public TokenFirebase idTokenFirebase { get; set; }
*/
        [NotNull]
        [Required]
        public int idPortes { get; set; }

        [NotNull]
        [Required]
        [StringLength(18)]
        public String cnpj { get; set; }

        //Só pus o aributo de email
        //public String email { get; set; }

        [NotNull]
        [StringLength(50)]
        [Required]
        public String razaoSocial { get; set; }

        [NotNull]
        [StringLength(30)]
        [Required]
        public String nomeFantasia { get; set; }

        [ForeignKey("idPortes")]
        public Porte Porte { get; set; }
    }
}
