using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.EnderecoCandidatos
{
    public class EnderecoCandidatoRepository : IEnderecoCandidatoRepository
    {
        private readonly DataContext _context;

        public EnderecoCandidatoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EnderecoCandidato> AddEnderecoCandidatosAsync(EnderecoCandidato novoEnderecoCandidato)
        {
            await _context.EnderecoCandidato.AddAsync(novoEnderecoCandidato);
            return novoEnderecoCandidato;

        }

        public async Task DeleteEnderecoCandidatoAsync(EnderecoCandidato enderecoCandidato)
        {
            _context.EnderecoCandidato.Remove(enderecoCandidato);
        }
        public async Task<EnderecoCandidato> GetEnderecoCandidatosByIdAsync(int id)
        {
            return await _context.EnderecoCandidato.FirstOrDefaultAsync(endCandi => endCandi.idCandidato == id);

        }
    }
}