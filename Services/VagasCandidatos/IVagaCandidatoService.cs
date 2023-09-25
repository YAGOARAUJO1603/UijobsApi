using UIJobsAPI.Models;

namespace UijobsApi.Services.VagasCandidatos
{
    public interface IVagaCandidatoService
    {
        public Task<IEnumerable<VagaCandidato>> GetAllVagaCandidatoAsync();

        public Task<VagaCandidato> GetVagaCandidatoByIdAsync(int id);
        public Task<VagaCandidato> AddVagaCandidatoAsync(VagaCandidato novaVagaCandidato);

        public Task DeleteVagaCandidatoByIdAsync(int id);
    }
}
