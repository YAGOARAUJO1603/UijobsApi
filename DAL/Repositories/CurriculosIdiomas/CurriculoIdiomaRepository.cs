using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.CurriculosIdiomas
{
    public class CurriculoIdiomaRepository : ICurriculoIdiomaRepository
    {
        private readonly DataContext _context;
<<<<<<< HEAD
        
=======
        7
>>>>>>> 082cb01ceb7037aaaa31e092c2bf6803ee31e40f
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
