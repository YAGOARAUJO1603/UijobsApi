using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.BeneficiosVagas
{
    public interface IBeneficioVagaRepository
    {
        public Task<BeneficioVaga> GetBeneficioVagaByIdAsync(int id);
        public Task<BeneficioVaga> AddBeneficioVagaAsync(BeneficioVaga novoBeneficioVaga);

        public Task DeleteBeneficioVagaByIdAsync(BeneficioVaga beneficioVaga);
    }
}
