using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.Idiomas
{
    public class IdiomaRepository : IIdiomaRepository
    {

        private readonly DataContext _context;

        public IdiomaRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Idioma> AddIdiomaAsync(Idioma novoIdioma)
        {
            await _context.AddAsync(novoIdioma);
            await _context.SaveChangesAsync();

            return novoIdioma;
        }

        public async Task DeleteIdiomaByIdAsync(int id)
        {
            var idiomaParaExcluir = await _context.Idiomas.FirstOrDefaultAsync(idioma => idioma.idIdiomas == id);

            if (idiomaParaExcluir != null)
            {
                _context.Idiomas.Remove(idiomaParaExcluir);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Idioma>> GetAllIdiomaAsync()
        {
            IEnumerable<Idioma> idiomas = await _context.Idiomas.ToListAsync();
            return idiomas;
        }

        public async Task<Idioma> GetIdiomaByIdAsync(int id)
        {
            Idioma idioma = await _context.Idiomas.FirstOrDefaultAsync(idioma => idioma.idIdiomas == id);
            return idioma;
        }
    }
}