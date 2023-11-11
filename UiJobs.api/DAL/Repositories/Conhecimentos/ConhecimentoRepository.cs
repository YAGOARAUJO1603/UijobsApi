using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Models.Enuns;

namespace UijobsApi.DAL.Repositories.Conhecimentos
{
    public class ConhecimentoRepository : IConhecimentoRepository
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ConhecimentoRepository(DataContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento)
        {
            await _context.Conhecimentos.AddAsync(novoConhecimento);
            return novoConhecimento;
        }

        public async Task DeleteConhecimentoByIdAsync(Conhecimento conhecimento)
        {
            _context.Conhecimentos.Remove(conhecimento);
            
        }

        public async Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync()
        {
            return await _context.Conhecimentos.ToListAsync();
        }

        public async Task<Conhecimento> GetConhecimentoByIdAsync(int id)
        {
            return await _context.Conhecimentos.FirstOrDefaultAsync(c => c.idConhecimentos == id);
        }

    }
 }
