using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Models;

namespace UIJobsAPI.Services.Interfaces
{
    public interface ICandidatoService
    {
        public Task<IEnumerable<Candidato>> GetAllCandidatosAsync();
        public Task<Candidato> GetCandidatoByIdAsync(int id);
        public Task<Candidato> AddCandidatoAsync(Candidato novoCandidato);

        public Task DeleteCandidatoByIdAsync(int id);
    }
}
