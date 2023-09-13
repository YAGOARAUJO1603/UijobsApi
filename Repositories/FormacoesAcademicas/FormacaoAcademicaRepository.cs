using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.FormacoesAcademicas
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
            await _context.AddAsync(novaFormacaoAcademica);
            await _context.SaveChangesAsync();
            return novaFormacaoAcademica;
        }

        public async Task DeleteFormacoesAcademicasByIdAsync(int id)
        {
            var formacaoAcademicaParaExcluir = await _context.FormacaoAcademica.FirstOrDefaultAsync(forAca => forAca.idFormacaoAcademica == id);

            if (formacaoAcademicaParaExcluir != null)
            {
                _context.FormacaoAcademica.Remove(formacaoAcademicaParaExcluir);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FormacaoAcademica>> GetAllFormacoesAcademicasAsync()
        {
            IEnumerable<FormacaoAcademica> formacaoAcademicas = await _context.FormacaoAcademica.ToListAsync();
            return formacaoAcademicas;
        }

        public async Task<FormacaoAcademica> GetFormacoesAcademicasByIdAsync(int id)
        {
            FormacaoAcademica formacaoAcademica = await _context.FormacaoAcademica.FirstOrDefaultAsync(forAca => forAca.idFormacaoAcademica == id);
            return formacaoAcademica;
        }
    }
}