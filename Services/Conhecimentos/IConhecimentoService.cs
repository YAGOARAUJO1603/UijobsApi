using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Conhecimentos
{
    public interface IConhecimentoService
    {
        public Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync();
        //Listar todos

        public Task<Conhecimento> GetConhecimentoByIdAsync(int id);
        //listar por id

        public Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento);

        public Task DeleteConhecimentoByIdAsync(int id);
    }
}