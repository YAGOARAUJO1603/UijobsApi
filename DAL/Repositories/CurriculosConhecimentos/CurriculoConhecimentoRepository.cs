using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.CurriculosConhecimentos
{
    public class CurriculoConhecimentoRepository : ICurriculoConhecimentoRepository
    {
        private readonly DataContext _context;
        public async Task<CurriculoConhecimento> AddCurriculoConhecimentoAsync(CurriculoConhecimento novoCurriculoConhecimento)
        {
            await _context.CurriculoConhecimentos.AddAsync(novoCurriculoConhecimento);
            return novoCurriculoConhecimento;
        }

        public  async Task DeleteCurriculoConhecimentoByIdAsync(CurriculoConhecimento curriculoConhecimento)
        {
            _context.CurriculoConhecimentos.Remove(curriculoConhecimento);
        }

        public async Task<IEnumerable<CurriculoConhecimento>> GetAllCurriculoConhecimentosAsync()
        {
            return await _context.CurriculoConhecimentos.ToListAsync();
        }

        public async Task<CurriculoConhecimento> GetCurriculoConhecimentoByIdAsync(int id)
        {
            return await _context.CurriculoConhecimentos.FirstOrDefaultAsync(curriculoConhecimento => curriculoConhecimento.idConhecimentos == id);
        }
    }
}
