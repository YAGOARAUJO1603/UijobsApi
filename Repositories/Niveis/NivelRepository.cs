using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.Niveis
{
    public class NivelRepository : INivelRepository
    {
        private readonly DataContext _context;

        public NivelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nivel>> GetAllNivelAsync()
        {
            IEnumerable<Nivel> niveis = await _context.Nivel.ToListAsync();
            return niveis;
        }

        public async Task<Nivel> GetNivelByIdAsync(int id)
        {
            Nivel nivel = await _context.Nivel.FirstOrDefaultAsync(nivel => nivel.idNivel == id);
            return nivel;
        }
    }
}