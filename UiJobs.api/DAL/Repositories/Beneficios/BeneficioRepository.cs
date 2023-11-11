using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Beneficios
{
    public class BeneficioRepository : IBeneficioRepository
    {
        private readonly DataContext _context;

        public BeneficioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Beneficio> AddBeneficioAsync(Beneficio novoBeneficio)
        {
            await _context.Beneficio.AddAsync(novoBeneficio);
            return novoBeneficio;
        }

        public async Task DeleteBeneficioByIdAsync(Beneficio beneficio)
        {
            _context.Beneficio.Remove(beneficio);
        }

        public async Task<IEnumerable<Beneficio>> GetAllBeneficioAsync()
        {
            return await _context.Beneficio.ToListAsync();
        }

        public async Task<Beneficio> GetBeneficioByIdAsync(int id)
        {
            return await _context.Beneficio.FirstOrDefaultAsync(benef => benef.idBeneficio == id);
        }
    }
}
