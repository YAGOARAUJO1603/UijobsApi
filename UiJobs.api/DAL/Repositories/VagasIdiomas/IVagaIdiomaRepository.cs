
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.VagasIdiomas
{
    public interface IVagaIdiomaRepository
    {
        //Listar todos
        public Task<IEnumerable<VagaIdioma>> GetAllVagaIdiomaAsync();

        //listar por id
        public Task<VagaIdioma> GetVagaIdiomaByIdAsync(int id);

        public Task<VagaIdioma> AddVagaIdiomaAsync(VagaIdioma novaVagaIdioma);

        public Task DeleteVagaIdiomaByIdAsync(VagaIdioma vagaIdioma);
    }
}
