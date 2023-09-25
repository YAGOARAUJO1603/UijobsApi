using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.VagasCandidatos
{
    public class VagaCandidatoRepository : IVagaCandidatoRepository
    {
        private readonly DataContext _context;
        public async Task<VagaCandidato> AddVagaCandidatoAsync(VagaCandidato novaVagaCandidato)
        {
            await _context.VagasCandidato.AddAsync(novaVagaCandidato);
            return novaVagaCandidato;
        }

        public async Task DeleteVagaCandidatoByIdAsync(VagaCandidato vagaCandidato)
        {
            _context.VagasCandidato.Remove(vagaCandidato);
        }

        public async Task<IEnumerable<VagaCandidato>> GetAllVagaCandidatoAsync()
        {
            return await _context.VagasCandidato.ToListAsync();
        }

        public async Task<VagaCandidato> GetVagaCandidatoByIdAsync(int id)
        {
            return await _context.VagasCandidato.FirstOrDefaultAsync(vagaCandi => vagaCandi.idVagas == id);
        }
    }
}
