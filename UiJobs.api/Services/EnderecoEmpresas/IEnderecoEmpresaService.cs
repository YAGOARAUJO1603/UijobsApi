namespace UijobsApi.Services.EnderecoEmpresas
{
    public interface IEnderecoEmpresaService
    {
        Task<EnderecoEmpresa> GetEnderecoEmpresaByIdAsync(int id);

        Task<EnderecoEmpresa> AddEnderecoEmpresaAsync(EnderecoEmpresa novoEnderecoEmpresa);
        Task DeleteEnderecoEmpresaAsync(int id);
    }
}
