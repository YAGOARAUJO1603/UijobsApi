using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.VagasConhecimentos
{
    public class VagaConhecimentoRepository : IVagaConhecimentoRepository
    {
        private readonly DataContext _context;

        public VagaConhecimentoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<VagaConhecimento> GetVagaConhecimentoByIdAsync(int id)
        {
            return await _context.VagasConhecimentos.FirstOrDefaultAsync(vagaConhe => vagaConhe.idConhecimentos == id);
        }

        public async Task<IEnumerable<VagaConhecimento>> GetAllVagaConhecimentoAsync()
        {
            return await _context.VagasConhecimentos.ToListAsync();
        }

        public async Task<VagaConhecimento> AddVagaConhecimentoAsync(VagaConhecimento novaVagaConhecimento)
        {
            await _context.VagasConhecimentos.AddAsync(novaVagaConhecimento);
            return novaVagaConhecimento;
        }

        public async Task DeleteVagaConhecimentoByIdAsync(VagaConhecimento vagaConhecimento)
        {
            _context.VagasConhecimentos.Remove(vagaConhecimento);
        }

        
    }
}
