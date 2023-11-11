using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Conhecimentos
{
    public interface IConhecimentoService
    {
        //Listar todos
        public Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync();

        //listar por id
        public Task<Conhecimento> GetConhecimentoByIdAsync(int id);

        public Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento);

        public Task DeleteConhecimentoByIdAsync(int id);
    }
}