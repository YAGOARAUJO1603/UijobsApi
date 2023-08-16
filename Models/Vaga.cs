using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Vaga
    {
        [Key]
        public int idVaga { get; set; }
        public Empresa idEmpresa { get; set; }
        public string cargo { get; set; }
        public string descricao { get; set; }
        public string inicioVigencia { get; set; }
        public string finalVigencia { get; set; }
        public string salario { get; set; }
        public int cargaHoraria { get; set; }
        public string localidade { get; set; }
        public int percAderencia { get; set; }
        public Vaga idSituacao { get; set; }

    }
}