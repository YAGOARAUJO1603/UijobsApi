using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public string nomeSocial { get; set; }
        public int qtdFuncionarios { get; set; }
        public string porte { get; set; }
        public string CEP { get; set; }
    }
}