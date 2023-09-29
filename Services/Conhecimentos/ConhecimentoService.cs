using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.Conhecimentos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Conhecimentos
{
    public class ConhecimentoService : IConhecimentoService
    {

        private readonly IConhecimentoRepository _conhecimentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConhecimentoService(IConhecimentoRepository idiomaRepository, IUnitOfWork unitOfWork)
        {
            _conhecimentoRepository = idiomaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync()
        {
            return await _conhecimentoRepository.GetAllConhecimentoAsync();
        }

        public async Task<Conhecimento> GetConhecimentoByIdAsync(int id)
        {
            Conhecimento conhecimento = await _conhecimentoRepository.GetConhecimentoByIdAsync(id);

            if (conhecimento == null)
            {
                throw new NotFoundException("Candidato");
            }

            return conhecimento;
        }


        public async Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento)
        {
            Conhecimento conhecimentoExistente = await _conhecimentoRepository.GetConhecimentoByIdAsync(novoConhecimento.idConhecimentos);
            if (conhecimentoExistente != null && conhecimentoExistente.Equals(novoConhecimento))
            {
                // bad request exception \/
                throw new Exception("Já existe um conhecimento com esse id.");
            }
            Conhecimento conhecimento = await _conhecimentoRepository.AddConhecimentoAsync(novoConhecimento);
            await _unitOfWork.SaveChangesAsync();
            return conhecimento;
        }


        public async Task DeleteConhecimentoByIdAsync(int id)
        {
            Conhecimento conhecimento = await _conhecimentoRepository.GetConhecimentoByIdAsync(id);

            if (conhecimento is null)
            {
                throw new NotFoundException("conhecimento com id não existe");
            }
            _conhecimentoRepository.DeleteConhecimentoByIdAsync(conhecimento);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}