using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    public class Beneficio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idBeneficiario")]
        public int IdBeneficio { get; set; }

        [Required]
        [Column("nomeBeneficiario")]
        public BeneficioEnum NomeBeneficio { get; set; }
    }
}
