using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.EnderecoEmpresas
{
    public class EnderecoEmpresaRepository : IEnderecoEmpresaRepository
    {
        private readonly DataContext _context;

        public EnderecoEmpresaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EnderecoEmpresa> AddEnderecoEmpresaAsync(EnderecoEmpresa novoEnderecoEmpresa)
        {
            await _context.EnderecoEmpresa.AddAsync(novoEnderecoEmpresa);
            return novoEnderecoEmpresa;
        }

        public async Task DeleteEnderecoEmpresaAsync(EnderecoEmpresa enderecoEmpresa)
        {
            _context.EnderecoEmpresa.Remove(enderecoEmpresa);
        }

        public async Task<EnderecoEmpresa> GetEnderecoEmpresaByIdAsync(int id)
        {
            return await _context.EnderecoEmpresa.FirstOrDefaultAsync(endEmp => endEmp.idEmpresa == id);
        }
    }
}
