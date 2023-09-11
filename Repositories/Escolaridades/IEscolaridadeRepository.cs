using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.Escolaridades
{
    public interface IEscolaridadeRepository
    {
        
        public Task<IEnumerable<Escolaridade>> GetAllEscolaridadeAsync();
        //Listar todos

        public Task<Escolaridade> GetEscolaridadeByIdAsync(int id);
        //listar por id

        public Task<Escolaridade> AddEscolaridadeAsync(Escolaridade novaEscolaridade);

        public Task  DeleteEscolaridadeByIdAsync(int id);


    }
}