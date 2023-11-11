using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models;


[Index(nameof(idEmpresa))]
public class EnderecoEmpresa
{
    [Key]
    [Required]
    public int idEmpresa { get; set; }

    [Required]
    [StringLength(8)]
    public string cep { get; set; }

    [Required]
    [StringLength(15)]
    public string logradouro { get; set; }

    [Required]
    [StringLength(50)]
    public string endereco { get; set; }

    [Required]
    [StringLength(5)]
    public string numero { get; set; }

    [StringLength(20)]
    public string complemento { get; set; }

    [Required]
    [StringLength(30)]
    public string bairro { get; set; }

    [Required]
    [StringLength(50)]
    public string cidade { get; set; }

    [Required]
    [StringLength(2)]
    public string uf { get; set; }

//Tá certo?

    [ForeignKey("idEmpresa")]
    public Empresa Empresa { get; set; }
}