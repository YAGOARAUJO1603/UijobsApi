using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Models;

namespace UIJobsAPI.Repositories.Interfaces
{
    public interface ICandidatoRepository
    {
        public Task<IEnumerable<Candidato>> GetAllCandidatosAsync();

        public Task<Candidato> GetCandidatoByIdAsync(int id);

        public Task<Candidato> GetCandidatoByEmailAsync(string email);

        public Task<Candidato> AddCandidatoAsync(Candidato novoCandidato);

        public Task  DeleteCandidatoByIdAsync(int id);
    }
}
