using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Beneficios
{
    public interface IBeneficioRepository
    {
        public Task<IEnumerable<Beneficio>> GetAllBeneficioAsync();

        public Task<Beneficio> GetBeneficioByIdAsync(int id);
        public Task<Beneficio> AddBeneficioAsync(Beneficio novoBeneficio);

        public Task DeleteBeneficioByIdAsync(Beneficio beneficio);
    }
}
