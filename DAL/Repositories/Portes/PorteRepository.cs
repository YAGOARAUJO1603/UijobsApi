using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Portes
{
    public class PorteRepository : IPorteRepository
    {
        private readonly DataContext _context;

        public PorteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Porte>> GetAllPorteAsync()
        {
            return await _context.Portes.ToListAsync();
        }

        public async Task<Porte> GetPorteByIdAsync(int id)
        {
            return await _context.Portes.FirstOrDefaultAsync(porte => porte.idPortes == id);
        }
    }
}
