using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Conhecimentos
{
    public interface IConhecimentoRepository
    {
        public Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync();
        //Listar todos

        public Task<Conhecimento> GetConhecimentoByIdAsync(int id);
        //listar por id

        public Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento);

        public Task DeleteConhecimentoByIdAsync(Conhecimento conhecimento);
    }
}