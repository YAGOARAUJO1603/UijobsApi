using UIJobsAPI.Models;

namespace UijobsApi.Services.VagasIdiomas
{
    public interface IVagaIdiomaService
    {
        //Listar todos
        public Task<IEnumerable<VagaIdioma>> GetAllVagaIdiomaAsync();

        //listar por id
        public Task<VagaIdioma> GetVagaIdiomaByIdAsync(int id);

        public Task<VagaIdioma> AddVagaIdiomaAsync(VagaIdioma novaVagaIdioma);

        public Task DeleteVagaIdiomaByIdAsync(int id);
    }
}
