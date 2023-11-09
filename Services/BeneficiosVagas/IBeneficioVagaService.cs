using UIJobsAPI.Models;

namespace UijobsApi.Services.BeneficiosVagas
{
    public interface IBeneficioVagaService
    {
       // public Task<IEnumerable<BeneficioVaga>> GetBeneficioVagaByIdAsync(int id);
        public Task<BeneficioVaga> GetBeneficioVagaAsync(int beneficioId, int vagaId);
        public Task<BeneficioVaga> AddBeneficioVagaAsync(BeneficioVaga novoBeneficioVaga);

        public Task DeleteBeneficioVagaByIdAsync(int idBeneficio, int idVaga);
    }
}