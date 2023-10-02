using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.SituacoesVagas
{
    public class SituacaoVagaRepository : ISituacaoVagaRepository
    {
        private readonly DataContext _context;

        public SituacaoVagaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SituacaoVaga>> GetAllSituacaoVagaAsync()
        {
            return await _context.SituacaoVaga.ToListAsync();
        }

        public async Task<SituacaoVaga> GetSituacaoVagaByIdAsync(int id)
        {
            return await _context.SituacaoVaga.FirstOrDefaultAsync(situacaoVaga => situacaoVaga.idSituacaoVaga == id);
        }
    }
}
