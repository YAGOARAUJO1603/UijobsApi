using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idConhecimentos))]
    public class Conhecimento
    {
        public int idConhecimentos { get; set; }
        public String nomeConhecimento { get; set; }
    }
}
