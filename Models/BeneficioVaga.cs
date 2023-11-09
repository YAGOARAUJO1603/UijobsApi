using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIJobsAPI.Models
{
    public class BeneficioVaga
    {
        [Key]
        [Column(Order = 0)]
        public int idVagas { get; set; }

        [Key]
        [Column(Order = 1)]
        public int idBeneficio { get; set; }

        [NotMapped]
        [ForeignKey("idVagas")]
        public Vaga Vagas { get; set; }

        [NotMapped]
        [ForeignKey("idBeneficio")]
        public Beneficio Beneficio { get; set; }
    }
}
