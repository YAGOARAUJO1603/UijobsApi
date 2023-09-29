using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using UijobsApi.DAL.Repositories.EnderecoCandidatos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.EnderecoCandidatos
{
    public class EnderecoCandidatoService : IEnderecoCandidatoService
    {

        private readonly IEnderecoCandidatoRepository _enderecoCandidatoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoCandidatoService(IEnderecoCandidatoRepository enderecoCandidatoRepository, IUnitOfWork unitOfWork)
        {
            _enderecoCandidatoRepository = enderecoCandidatoRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<EnderecoCandidato> AddEnderecoCandidatosAsync(EnderecoCandidato novoEnderecoCandidato)
        {
            EnderecoCandidato enderecoCandidatoExistente = await _enderecoCandidatoRepository.GetEnderecoCandidatosByIdAsync(novoEnderecoCandidato.idCandidato);

            if (enderecoCandidatoExistente != null && enderecoCandidatoExistente.Equals(novoEnderecoCandidato))
            {
                // bad request exception \/
                throw new Exception("Já existe um candidato com esse id endereco Cadastrado.");
            }
            EnderecoCandidato enderecoCandidato = await _enderecoCandidatoRepository.AddEnderecoCandidatosAsync(novoEnderecoCandidato);
            await _unitOfWork.SaveChangesAsync();
            return enderecoCandidato;
        }

        public async Task DeleteEnderecoCandidatoByIdAsync(int id)
        {
            EnderecoCandidato enderecoCandidato = await _enderecoCandidatoRepository.GetEnderecoCandidatosByIdAsync(id);

            if (enderecoCandidato is null)
            {
                throw new NotFoundException("Endereco com id não existe");
            }
            _enderecoCandidatoRepository.DeleteEnderecoCandidatoAsync(enderecoCandidato);
            await _unitOfWork.SaveChangesAsync();
        }



        public async Task<EnderecoCandidato> GetEnderecoCandidatosByIdAsync(int id)
        {
            EnderecoCandidato enderecoCandidato = await _enderecoCandidatoRepository.GetEnderecoCandidatosByIdAsync(id);

            if (enderecoCandidato == null)
            {
                throw new NotFoundException("Endereco Candidato");
            }

            return enderecoCandidato;
        }
    }
}