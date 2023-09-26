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

<<<<<<< HEAD
        public Task DeleteCurriculoByIdAsync(Curriculo curriculo);
=======
        public Task DeleteCurriculoByIdAsync(Curriculo curriculo;
>>>>>>> 082cb01ceb7037aaaa31e092c2bf6803ee31e40f

    }
}