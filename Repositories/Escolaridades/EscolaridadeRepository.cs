using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.Escolaridades
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
            await _context.AddAsync(novaEscolaridade);
            await _context.SaveChangesAsync();

            return novaEscolaridade;
        }


        public async Task DeleteEscolaridadeByIdAsync(int id)
        {
            var escolaridadeParaExcluir = await _context.Escolaridade.FirstOrDefaultAsync(escol => escol.idEscolaridade == id);

            if (escolaridadeParaExcluir != null)
            {
                _context.Escolaridade.Remove(escolaridadeParaExcluir);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Escolaridade>> GetAllEscolaridadeAsync()
        {
            IEnumerable<Escolaridade> escolaridades = await _context.Escolaridade.ToListAsync();
            return escolaridades;
        }


        public async Task<Escolaridade> GetEscolaridadeByIdAsync(int id)
        {
            Escolaridade escolaridade = await _context.Escolaridade.FirstOrDefaultAsync(escol => escol.idEscolaridade == id);
            return escolaridade;
        }
    }
}