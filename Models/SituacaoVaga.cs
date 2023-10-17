using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    public class SituacaoVaga
    {
        [Key]
        [NotNull]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSituacaoVaga { get; set; }

        [NotNull]
        [StringLength(15)]
        [Required]
        public string situacaoAtual { get; set; }
    }
}
