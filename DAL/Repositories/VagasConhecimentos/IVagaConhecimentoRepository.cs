using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.VagasConhecimentos
{
    public interface IVagaConhecimentoRepository
    {
        //Listar todos
        public Task<IEnumerable<VagaConhecimento>> GetAllVagaConhecimentoAsync();

        //listar por id
        public Task<VagaConhecimento> GetVagaConhecimentoByIdAsync(int id);

        public Task<VagaConhecimento> AddVagaConhecimentoAsync(VagaConhecimento novaVagaConhecimento);

        public Task DeleteVagaConhecimentoByIdAsync(VagaConhecimento vagaConhecimento);
    }
}
