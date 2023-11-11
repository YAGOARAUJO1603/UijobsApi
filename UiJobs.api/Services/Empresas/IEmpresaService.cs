using UIJobsAPI.Models;

namespace UijobsApi.Services.Empresas
{
    public interface IEmpresaService
    {
        Task<Empresa> GetEmpresaByIdAsync(int id);
        Task<Empresa> AddEmpresaAsync(Empresa novaEmpresa);
        Task DeleteEmpresaAsync(int id);
    }
}
