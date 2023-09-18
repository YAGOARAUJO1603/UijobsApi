using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Models.Enuns;

namespace UijobsApi.DAL.Repositories.Conhecimentos
{
    public class ConhecimentoRepository : IConhecimentoRepository
    {
        private readonly DataContext _context;

        public ConhecimentoRepository(DataContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento)
        {
            await _context.Conhecimentos.AddAsync(novoConhecimento);
            return novoConhecimento;
        }

        public async Task DeleteConhecimentoByIdAsync(Conhecimento id)
        {
            _context.Conhecimentos.Remove(id);
        }

        public async Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync()
        {
            return await _context.Conhecimentos.ToListAsync();
        }

        public async Task<Conhecimento> GetConhecimentoByIdAsync(int id)
        {
            return await _context.Conhecimentos.FirstOrDefaultAsync(conheci => conheci.idConhecimentos == id);
        }

    }
 }
