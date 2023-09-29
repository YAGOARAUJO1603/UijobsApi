using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UijobsApi.DAL.Repositories.Idiomas;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories
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
            await _context.Idiomas.AddAsync(novoIdioma);
            return novoIdioma;
            //await _context.SaveChangesAsync(); -> UNIT OF WORK
        }

        public async Task DeleteIdiomaByIdAsync(Idioma idioma)
        {
            _context.Idiomas.Remove(idioma);
        }

        public async Task<IEnumerable<Idioma>> GetAllIdiomaAsync()
        {
            return await _context.Idiomas.ToListAsync();
        }

        public async Task<Idioma> GetIdiomaByIdAsync(int id)
        {
            return await _context.Idiomas.FirstOrDefaultAsync(idioma => idioma.idIdiomas == id);
        }
    }
}