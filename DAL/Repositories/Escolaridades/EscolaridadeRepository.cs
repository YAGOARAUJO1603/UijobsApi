using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Escolaridades
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {


        private readonly DataContext _context;

        public EscolaridadeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Escolaridade> AddEscolaridadeAsync(Escolaridade novaEscolaridade)
        {
            await _context.Escolaridade.AddAsync(novaEscolaridade);
            return novaEscolaridade;
        }


        public async Task DeleteEscolaridadeByIdAsync(Escolaridade id)
        {
            _context.Escolaridade.Remove(id);
        }

        public async Task<IEnumerable<Escolaridade>> GetAllEscolaridadeAsync()
        {
            return await _context.Escolaridade.ToListAsync();
        }


        public async Task<Escolaridade> GetEscolaridadeByIdAsync(int id)
        {
            return await _context.Escolaridade.FirstOrDefaultAsync(escola => escola.idEscolaridade == id);

        }
    }
}