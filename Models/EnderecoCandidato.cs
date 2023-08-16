using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class EnderecoCandidato
    {
        [Key]
        public int Id { get; set; }
        public string CEP { get; set; }
        //Tirar logradouro, mesma coisa que endereço
        public string logradouro { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string  complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
    }
}