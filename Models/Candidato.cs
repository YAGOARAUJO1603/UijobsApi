using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UijobsApi.Models
{
    public class Candidato
    {
        public int Id {get; set;}
        public string NomeMae {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}
        public string CEP {get; set;}
    }
}