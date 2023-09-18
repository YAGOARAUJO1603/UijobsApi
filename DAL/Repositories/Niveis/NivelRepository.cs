using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Niveis
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
            return await _context.Nivel.ToListAsync();

        }

        public async Task<Nivel> GetNivelByIdAsync(int id)
        {
            return await _context.Nivel.FirstOrDefaultAsync(nivel => nivel.idNivel == id);

        }
    }
}