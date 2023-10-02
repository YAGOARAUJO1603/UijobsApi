using UIJobsAPI.Models;

namespace UijobsApi.Services.BeneficiosVagas
{
    public interface IBeneficioVagaService
    {
        public Task<BeneficioVaga> GetBeneficioVagaByIdAsync(int id);
        public Task<BeneficioVaga> AddBeneficioVagaAsync(BeneficioVaga novoBeneficioVaga);

        public Task DeleteBeneficioVagaByIdAsync(int id);
    }
}
