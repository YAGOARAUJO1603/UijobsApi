using UIJobsAPI.Models;

namespace UijobsApi.Services.VagasConhecimentos
{
    public interface IVagaConhecimentoService
    {
        //Listar todos
        public Task<IEnumerable<VagaConhecimento>> GetAllVagaConhecimentoAsync();

        //listar por id
        public Task<VagaConhecimento> GetVagaConhecimentoByIdAsync(int id);

        public Task<VagaConhecimento> AddVagaConhecimentoAsync(VagaConhecimento novaVagaConhecimento);

        public Task DeleteVagaConhecimentoByIdAsync(int id);
    }
}
