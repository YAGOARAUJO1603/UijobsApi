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

        public async Task DeleteBeneficioVagaByIdAsync(int idBeneficio, int idVaga)
        {
            var beneficioVaga = await _context.BeneficioVagas.FirstOrDefaultAsync(bv => bv.idBeneficio == idBeneficio && bv.idVagas == idVaga);

            if (beneficioVaga != null)
            {
                _context.BeneficioVagas.Remove(beneficioVaga);
            }
        }

        public async Task<BeneficioVaga> GetBeneficioVagaAsync(int beneficioId, int vagaId)
        {
            return await _context.BeneficioVagas.FirstOrDefaultAsync(bv => bv.idBeneficio == beneficioId && bv.idVagas == vagaId);
        }

        /*public async Task<BeneficioVaga> GetBeneficioVagaByIdAsync(int id)
        {
            return await _context.BeneficioVagas.FirstOrDefaultAsync(benefVaga => benefVaga.idBeneficio == id);
        }*/

       /* public async Task<IEnumerable<BeneficioVaga>> GetBeneficioVagaByIdAsync(int id)
        {
            IEnumerable<BeneficioVaga> beneficioVaga = (IEnumerable<BeneficioVaga>)await _context.BeneficioVagas.FirstOrDefaultAsync(benefVaga => benefVaga.idBeneficio == id);
            return beneficioVaga;
        } */
    }
}
