using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Niveis
{
    public interface INivelService
    {
        public Task<IEnumerable<Nivel>> GetAllNivelAsync();
        //Listar todos

        public Task<Nivel> GetNivelByIdAsync(int id);
        //listar por id
    }
}