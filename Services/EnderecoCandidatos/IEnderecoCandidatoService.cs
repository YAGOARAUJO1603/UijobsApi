using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Services.EnderecoCandidatos
{
    public interface IEnderecoCandidatoService
    {
        Task<EnderecoCandidato> GetEnderecoCandidatosByIdAsync(int id);
        Task<EnderecoCandidato> AddEnderecoCandidatosAsync(EnderecoCandidato novoEnderecoCandidato);
        Task DeleteEnderecoCandidatoByIdAsync(int id);
    }
}