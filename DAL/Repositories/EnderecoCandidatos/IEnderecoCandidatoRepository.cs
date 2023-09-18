using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.EnderecoCandidatos
{
    public interface IEnderecoCandidatoRepository
    {
        Task<EnderecoCandidato> GetEnderecoCandidatosByIdAsync(int id);

        Task<IEnumerable<EnderecoCandidato>> GetAllEnderecoCandidato();
        Task<EnderecoCandidato> AddEnderecoCandidatosAsync(EnderecoCandidato novoEnderecoCandidato);
        Task DeleteEnderecoCandidatoAsync(EnderecoCandidato id);


    }
}