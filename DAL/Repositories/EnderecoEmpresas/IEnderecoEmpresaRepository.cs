using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.EnderecoEmpresas
{
    public interface IEnderecoEmpresaRepository
    {
        Task<EnderecoEmpresa> GetEnderecoEmpresaByIdAsync(int id);
        Task<EnderecoEmpresa> AddEnderecoEmpresaAsync(EnderecoEmpresa novoEnderecoEmpresa);
        Task DeleteEnderecoEmpresaAsync(EnderecoEmpresa enderecoEmpresa);
    }
}
