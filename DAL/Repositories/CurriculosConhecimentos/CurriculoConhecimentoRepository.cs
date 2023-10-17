using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.CurriculosConhecimentos
{
    public class CurriculoConhecimentoRepository : ICurriculoConhecimentoRepository
    {
        private readonly DataContext _context;
        
        public CurriculoConhecimentoRepository(DataContext context)
        { 
            _context = context;
        }
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
            var a =  await _context.CurriculoConhecimentos.ToListAsync();
            
            return a;
        }

        public async Task<CurriculoConhecimento> GetCurriculoConhecimentoByIdAsync(int id)
        {
            return await _context.CurriculoConhecimentos.FirstOrDefaultAsync(curriculoConhecimento => curriculoConhecimento.idConhecimentos == id);
        }
    }
}
