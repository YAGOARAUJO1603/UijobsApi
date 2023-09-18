using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Niveis
{
    public interface INivelRepository
    {

        public Task<IEnumerable<Nivel>> GetAllNivelAsync();
        //Listar todos

        public Task<Nivel> GetNivelByIdAsync(int id);
        //listar por id
    }
}