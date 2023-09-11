using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.Curriculos
{
    public class CurriculoRepository : ICurriculoRepository
    {
        private readonly DataContext _context;

        public CurriculoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Curriculo> AddCurriculoAsync(Curriculo novoCurriculo)
        {
            await _context.AddAsync(novoCurriculo);
            await _context.SaveChangesAsync();
            return novoCurriculo;
        }

        public async Task DeleteCurriculoByIdAsync(int id)
        {
            var curriculoParaExcluir = await _context.Curriculo.FirstOrDefaultAsync(curri => curri.idCurriculo == id);

            if (curriculoParaExcluir != null)
            {
                _context.Curriculo.Remove(curriculoParaExcluir);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Curriculo> GetCurriculoByIdAsync(int id)
        {
            Curriculo curriculo = await _context.Curriculo.FirstOrDefaultAsync(curri => curri.idCurriculo == id);
            return curriculo;
        }
    }
}