using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.EnderecoCandidatos
{
    public interface IEnderecoCandidatoRepository
    {
        Task<EnderecoCandidato> GetEnderecoCandidatosByIdAsync(int id);
        Task<EnderecoCandidato> AddEnderecoCandidatosAsync(EnderecoCandidato novoEnderecoCandidato);
        Task DeleteEnderecoCandidatoAsync(EnderecoCandidato enderecoCandidato);


    }
}