using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.VagasCandidatos
{
    public interface IVagaCandidatoRepository
    {
        public Task<IEnumerable<VagaCandidato>> GetAllVagaCandidatoAsync();

        public Task<VagaCandidato> GetVagaCandidatoByIdAsync(int id);
        public Task<VagaCandidato> AddVagaCandidatoAsync(VagaCandidato novaVagaCandidato);

        public Task DeleteVagaCandidatoByIdAsync(VagaCandidato vagaCandidato);
    }
}
