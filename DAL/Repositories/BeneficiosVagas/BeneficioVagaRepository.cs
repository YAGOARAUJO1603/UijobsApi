using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.BeneficiosVagas
{
    public class BeneficioVagaRepository : IBeneficioVagaRepository
    {
        private readonly DataContext _context;

        public BeneficioVagaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<BeneficioVaga> AddBeneficioVagaAsync(BeneficioVaga novoBeneficioVaga)
        {
            await _context.BeneficioVagas.AddAsync(novoBeneficioVaga);
            return novoBeneficioVaga;
        }

        public async Task DeleteBeneficioVagaByIdAsync(BeneficioVaga beneficioVaga)
        {
            _context.BeneficioVagas.Remove(beneficioVaga);
        }

        public async Task<BeneficioVaga> GetBeneficioVagaByIdAsync(int id)
        {
            return await _context.BeneficioVagas.FirstOrDefaultAsync(benefVaga => benefVaga.idBeneficio == id);
        }
    }
}
