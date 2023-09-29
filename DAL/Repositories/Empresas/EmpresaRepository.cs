using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Empresas
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DataContext _context;

        public EmpresaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Empresa> AddEmpresaAsync(Empresa novaEmpresa)
        {
            await _context.Empresa.AddAsync(novaEmpresa);
            return novaEmpresa;
        }

        public async Task DeleteEmpresaAsync(Empresa empresa)
        {
            _context.Empresa.Remove(empresa);
        }

        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            return await _context.Empresa.FirstOrDefaultAsync(empresa => empresa.idEmpresa == id);
        }
    }
}
