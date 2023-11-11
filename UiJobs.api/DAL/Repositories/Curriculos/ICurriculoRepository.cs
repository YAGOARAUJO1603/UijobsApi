using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Curriculos
{
    public interface ICurriculoRepository
    {

        public Task<Curriculo> GetCurriculoByIdAsync(int id);
        //listar por id

        public Task<Curriculo> AddCurriculoAsync(Curriculo novoCurriculo);

        public Task DeleteCurriculoByIdAsync(Curriculo curriculo);

    }
}