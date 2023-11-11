using UIJobsAPI.Models;

namespace UijobsApi.Services.Beneficios
{
    public interface IBeneficioService
    {
        public Task<IEnumerable<Beneficio>> GetAllBeneficioAsync();

        public Task<Beneficio> GetBeneficioByIdAsync(int id);
        public Task<Beneficio> AddBeneficioAsync(Beneficio novoBeneficio);

        public Task DeleteBeneficioByIdAsync(int id);
    }
}
