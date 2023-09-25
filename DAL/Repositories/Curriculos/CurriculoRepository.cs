using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Curriculos
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
            await _context.Curriculo.AddAsync(novoCurriculo);
            return novoCurriculo;
        }

        public async Task DeleteCurriculoByIdAsync(Curriculo curriculo)
        {
            _context.Curriculo.Remove(curriculo);
        }

        public async Task<Curriculo> GetCurriculoByIdAsync(int id)
        {
            return await _context.Curriculo.FirstOrDefaultAsync(curri => curri.idCurriculo == id);
        }
    }
}