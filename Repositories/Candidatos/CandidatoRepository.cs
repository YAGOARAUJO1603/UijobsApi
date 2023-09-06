using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Repositories.Interfaces;

namespace UIJobsAPI.Repositories.Candidatos
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
            IEnumerable<Candidato> candidatos = await _context.Candidato.ToListAsync();
            return candidatos;
        }

        public async Task<Candidato> GetCandidatoByIdAsync(int id)
        {
            Candidato candidato = await _context.Candidato.FirstOrDefaultAsync(c => c.idCandidato == id);
            return candidato;
        }

        public async Task<Candidato> AddCandidatoAsync([FromBody] Candidato novoCandidato)
        {

            Candidato currentCandidato = await _context.Candidato.FirstOrDefaultAsync(c => c.email == novoCandidato.email);

            if (currentCandidato != null && currentCandidato.Equals(novoCandidato))
            {
                throw new Exception("Usuário já existe");
            }

            await _context.AddAsync(novoCandidato);
            await _context.SaveChangesAsync();
            return novoCandidato;
        }

        

        public async Task<Candidato> GetCandidatoByEmailAsync(string email)
        {
            return await _context.Candidato.FirstOrDefaultAsync(c => c.email == email);

        }

        public async Task DeleteCandidatoByIdAsync(int id)
        {
            var candidatoParaExcluir = await _context.Candidato.FirstOrDefaultAsync(c => c.idCandidato == id);

            if (candidatoParaExcluir != null)
            {
                _context.Candidato.Remove(candidatoParaExcluir);
                await _context.SaveChangesAsync();
            }
        }



    }
}
