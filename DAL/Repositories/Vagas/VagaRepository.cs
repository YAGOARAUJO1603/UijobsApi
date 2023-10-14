using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Vagas
{
    public class VagaRepository : IVagaRepository
    {
        private readonly DataContext _context;

        public VagaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Vaga> GetVagaByIdAsync(int id)
        {
            return await _context.Vagas.FirstOrDefaultAsync(vaga => vaga.idVagas == id);
        }

        public async Task<IEnumerable<Vaga>> GetAllVagaAsync()
        {
            return await _context.Vagas.ToListAsync();
        }

        public async Task<Vaga> AddVagaAsync(Vaga novaVaga)
        {
            await _context.Vagas.AddAsync(novaVaga);
            return novaVaga;
        }

        public async Task DeleteVagaByIdAsync(Vaga vaga)
        {
            _context.Vagas.Remove(vaga);
        }
    }
}
