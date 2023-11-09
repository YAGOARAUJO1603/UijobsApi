using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idConhecimentos))]
    public class Conhecimentos
    {
        public int idConhecimentos { get; set; }
        public string nomeConhecimento { get; set; }
    }
}
