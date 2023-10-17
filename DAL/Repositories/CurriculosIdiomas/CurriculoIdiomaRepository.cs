using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.CurriculosIdiomas
{
    public class CurriculoIdiomaRepository : ICurriculoIdiomaRepository
    {
        private readonly DataContext _context;

        public CurriculoIdiomaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CurriculoIdioma> AddCurriculoIdiomaAsync(CurriculoIdioma novoCurriculoIdioma)
        {
            await _context.CurriculoIdiomas.AddAsync(novoCurriculoIdioma);
            return novoCurriculoIdioma;
        }

        public async Task DeleteCurriculoIdiomaByIdAsync(CurriculoIdioma curriculoIdioma)
        {
            _context.CurriculoIdiomas.Remove(curriculoIdioma);
        }

        public async Task<IEnumerable<CurriculoIdioma>> GetAllCurriculoIdiomasAsync()
        {
            return await _context.CurriculoIdiomas.ToListAsync();
        }

        public async Task<CurriculoIdioma> GetCurriculoIdiomasByIdAsync(int id)
        {
            return await _context.CurriculoIdiomas.FirstOrDefaultAsync(curriculoIdioma => curriculoIdioma.idCurriculo == id);
        }
    }
}
