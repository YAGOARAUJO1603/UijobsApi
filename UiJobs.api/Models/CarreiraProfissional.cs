using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models;

namespace UIJobsAPI.Models;
public class CarreiraProfissional
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int sqCarreiraProfissional { get; set; }

    [Required]
    public int idCurriculo { get; set; }

    [Required]
    [MaxLength(150)]
    public string nomeEmpresa { get; set; }

    [Required]
    public DateTime tempoInicio { get; set; }

    [Required]
    public DateTime tempoFim { get; set; }

    [Required]
    [MaxLength(50)]
    public string cargo { get; set; }

    [ForeignKey("idCurriculo")]
    public Curriculo Curriculo { get; set; }
}