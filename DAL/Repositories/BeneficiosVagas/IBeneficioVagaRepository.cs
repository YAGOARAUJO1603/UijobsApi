using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.BeneficiosVagas
{
    public interface IBeneficioVagaRepository
    {
       // public Task<IEnumerable<BeneficioVaga>> GetBeneficioVagaByIdAsync(int id);
        public Task<BeneficioVaga> GetBeneficioVagaAsync(int beneficioId, int vagaId);
        public Task<BeneficioVaga> AddBeneficioVagaAsync(BeneficioVaga novoBeneficioVaga);

        public Task DeleteBeneficioVagaByIdAsync(int idBeneficio, int idVaga);
    }
}
