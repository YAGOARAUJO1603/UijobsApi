using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Curriculos
{
    public interface ICurriculoService
    {
        public Task<Curriculo> GetCurriculoByIdAsync(int id);
        //listar por id

        public Task<Curriculo> AddCurriculoAsync(Curriculo novoCurriculo);

        public Task DeleteCurriculoByIdAsync(int id);
    }
}