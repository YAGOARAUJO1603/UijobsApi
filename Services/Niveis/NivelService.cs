using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.Niveis;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UIJobsAPI.Models.Enuns;

namespace UijobsApi.Services.Niveis
{
    public class NivelService : INivelService
    {
        private readonly INivelRepository _nivelRepository;

        public NivelService(INivelRepository nivelRepository)
        {
            _nivelRepository = nivelRepository;
        }

        public async Task<IEnumerable<Nivel>> GetAllNivelAsync()
        {
            return await _nivelRepository.GetAllNivelAsync();
        }

        public async Task<Nivel> GetNivelByIdAsync(int id)
        {
            Nivel nivel = await _nivelRepository.GetNivelByIdAsync(id);

            if (nivel == null)
            {
                throw new NotFoundException("Candidato");
            }

            /*if (nivel.idNivel == (int)NivelEnum.Especialista)
            {

            }*/

            return nivel;
        }
    }
}