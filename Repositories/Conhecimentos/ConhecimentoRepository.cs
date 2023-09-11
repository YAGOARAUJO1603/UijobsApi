using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Models.Enuns;

namespace UijobsApi.Repositories.Conhecimentos
{
    public class ConhecimentoRepository : IConhecimentoRepository
    {
        private readonly DataContext _context;

        public ConhecimentoRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento)
        {
            await _context.AddAsync(novoConhecimento);
            await _context.SaveChangesAsync();
            return novoConhecimento;
        }

        public async Task DeleteConhecimentoByIdAsync(int id)
        {
            var conhecimentoParaExcluir = await _context.Conhecimentos.FirstOrDefaultAsync(conhe => conhe.idConhecimentos == id);

            if (conhecimentoParaExcluir != null)
            {
                _context.Conhecimentos.Remove(conhecimentoParaExcluir);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync()
        {
            IEnumerable<Conhecimento> conhecimentos = await _context.Conhecimentos.ToListAsync();
            return conhecimentos;
        }

        public async Task<Conhecimento> GetConhecimentoByIdAsync(int id)
        {
            Conhecimento conhecimento = await _context.Conhecimentos.FirstOrDefaultAsync(conhe => conhe.idConhecimentos == id);
            return conhecimento;
        }
    }
}