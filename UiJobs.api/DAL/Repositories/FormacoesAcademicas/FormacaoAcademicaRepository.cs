using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.FormacoesAcademicas
{
    public class FormacaoAcademicaRepository : IFormacaoAcademicaRepository
    {
        private readonly DataContext _context;

        public FormacaoAcademicaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<FormacaoAcademica> AddFormacoesAcademicasAsync(FormacaoAcademica novaFormacaoAcademica)
        {
            await _context.FormacaoAcademica.AddAsync(novaFormacaoAcademica);
            return novaFormacaoAcademica;
        }

        public async Task DeleteFormacoesAcademicasByIdAsync(FormacaoAcademica formacaoAcademica)
        {
            _context.FormacaoAcademica.Remove(formacaoAcademica);
        }

        public async Task<IEnumerable<FormacaoAcademica>> GetAllFormacoesAcademicasAsync()
        {
            return await _context.FormacaoAcademica.ToListAsync();
        }

        public async Task<FormacaoAcademica> GetFormacoesAcademicasByIdAsync(int id)
        {
            return await _context.FormacaoAcademica.FirstOrDefaultAsync(formaAcad => formaAcad.idFormacaoAcademica == id);

        }
    }
}