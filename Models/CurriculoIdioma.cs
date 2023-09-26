using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UIJobsAPI.Models
{
    [PrimaryKey(nameof(idCurriculo), nameof(idIdiomas))]

    public class CurriculoIdioma
    {
        [Column(Order = 0)]
        public int idCurriculo { get; set; }

        [Column(Order = 1)]
        public int idIdiomas { get; set; }

        //Novo
        public int idNivel { get; set; }

        [ForeignKey("idCurriculo")]
        public Curriculo Curriculo { get; set; }

        [ForeignKey("idIdiomas")]
        public Idioma Idiomas { get; set; }

        [ForeignKey("idNivel")]
        public Nivel Nivel{ get; set; }
    }
}
