using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UIJobsAPI.Models
{
    [Index(nameof(idEmpresa), nameof(idSituacaoVaga), nameof(idEscolaridade))]
    public class Vaga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idVaga { get; set; }

        [Required]
        public int idEscolaridade { get; set; }

        [Required]
        public int idSituacaoVaga { get; set; }

        [Required]
        public int idEmpresa { get; set; }

        [StringLength(25)]
        public string cargo { get; set; }

        [StringLength(100)]
        public string descricao { get; set; }

        public DateTime? inicioVigencia { get; set; }

        public DateTime? finalVigencia { get; set; }

        public double? salario { get; set; }

        public ushort? cargaHoraria { get; set; }

        public string localidade { get; set; }

        public double? percAderencia { get; set; }

        [StringLength(30)]
        public string escalaHorario { get; set; }

        [ForeignKey("idEmpresa")]
        public Empresa Empresa { get; set; }

        [ForeignKey("idSituacaoVaga")]
        public SituacaoVaga SituacaoVaga { get; set; }

        [ForeignKey("idEscolaridade")]
        public Escolaridade Escolaridade { get; set; }
    }
}
