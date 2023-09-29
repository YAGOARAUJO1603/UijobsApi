using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Candidatos
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly DataContext _context;

        public CandidatoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidato>> GetAllCandidatosAsync()
        {
            return await _context.Candidato.ToListAsync();

        }

        public async Task<Candidato> GetCandidatoByIdAsync(int id)
        {
            return await _context.Candidato.FirstOrDefaultAsync(candidato => candidato.idCandidato == id);
        }

        public async Task<Candidato> AddCandidatoAsync([FromBody] Candidato novoCandidato)
        {
            await _context.Candidato.AddAsync(novoCandidato);
            return novoCandidato;
        }



        public async Task<Candidato> GetCandidatoByEmailAsync(string email)
        {
            return await _context.Candidato.FirstOrDefaultAsync(c => c.email == email);

        }

        public async Task DeleteCandidatoByIdAsync(Candidato candidato)
        {
            _context.Candidato.Remove(candidato);
        }



    }
}
