using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.EnderecoCandidatos
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
            await _context.AddAsync(novoEnderecoCandidato);
            await _context.SaveChangesAsync();

            return novoEnderecoCandidato;
        }

        public async Task DeleteEnderecoCandidatoAsync(int id)
        {
            var enderecoParaExcluir = await _context.EnderecoCandidato.FirstOrDefaultAsync(e => e.idEnderecoCandidato ==id);

            if (enderecoParaExcluir != null)
            {
                _context.EnderecoCandidato.Remove(enderecoParaExcluir);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<EnderecoCandidato> GetEnderecoCandidatosByIdAsync(int id)
        {
            EnderecoCandidato enderecoCandidato = await _context.EnderecoCandidato.FirstOrDefaultAsync(e => e.idEnderecoCandidato == id);
            return enderecoCandidato;
        }
    }
}