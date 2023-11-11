using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UIJobsAPI.Models
{
    public class EnderecoCandidato
    {
        [Key]
        [Required]
        public int idCandidato { get; set; }

        [Required]
        public string cep { get; set; }

        [Required]
        [MaxLength(15)]
        public string logradouro { get; set; }

        [Required]
        [MaxLength(50)]
        public string endereco { get; set; }

        [Required]
        [MaxLength(5)]
        public string numero { get; set; }

        [MaxLength(15)]
        public string? complemento { get; set; }

        [Required]
        [MaxLength(30)]
        public string bairro { get; set; }

        [Required]
        [MaxLength(50)]
        public string cidade { get; set; }

        [Required]
        [MaxLength(2)]
        public string uf { get; set; }

        [ForeignKey("idCandidato")]
        public Candidato Candidato { get; set; }
    }
}
