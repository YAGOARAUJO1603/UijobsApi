using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Empresas
{
    public interface IEmpresaRepository
    {
        Task<Empresa> GetEmpresaByIdAsync(int id);
        Task<Empresa> AddEmpresaAsync(Empresa novaEmpresa);
        Task DeleteEmpresaAsync(Empresa empresa);
    }
}
