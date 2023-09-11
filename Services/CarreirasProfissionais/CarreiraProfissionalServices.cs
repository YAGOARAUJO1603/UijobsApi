using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UijobsApi.Repositories.CarreirasProfissionais;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Repositories.Interfaces;
using UIJobsAPI.Exceptions;


namespace UijobsApi.Services.CarreirasProfissionais
{
    public class CarreiraProfissionalServices : ICarreiraProfissionalServices
    {

        private readonly ICarreiraProfissionalRepository _carreiraProfissionalRepository;
        private object _context;

        public CarreiraProfissionalServices(ICarreiraProfissionalRepository carreiraProfissionalRepository)
        {
            _carreiraProfissionalRepository = carreiraProfissionalRepository;
        }


        public async Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional novaCarreiraProfissional)
        {
            // Verifique se a data de início e a data de fim foram fornecidas
            if (novaCarreiraProfissional.tempoInicio == null || novaCarreiraProfissional.tempoFim == null)
            {
                // Lançar uma exceção ou retornar um erro, pois ambas as datas são obrigatórias
                throw new ArgumentException("As datas de início e término são obrigatórias.");
            }

            // Calcule a diferença de anos entre as datas de início e término
            int anosDeExperiencia = novaCarreiraProfissional.tempoFim.Year - novaCarreiraProfissional.tempoInicio.Year;

            // Verifique se a experiência é maior do que 20 anos
            if (anosDeExperiencia > 20)
            {
                // Lançar uma exceção ou retornar um erro informando que a experiência não pode ser superior a 20 anos
                throw new ArgumentException("A experiência não pode ser superior a 20 anos.");
            }

            // Continue com a adição da carreira profissional usando o repositório
            var carreiraProfissionalAdicionada = await _carreiraProfissionalRepository.AddCarreiraProfissionalAsync(novaCarreiraProfissional);

            return carreiraProfissionalAdicionada;
        }

  

        public async Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id)
        {
            CarreiraProfissional carreiraProfissional = await _carreiraProfissionalRepository.GetCarreiraProfissionalByIdAsync(id);

            if (carreiraProfissional == null)
            {
                throw new NotFoundException("Carreira Profissional");
            }

            return carreiraProfissional;
        }

        public async Task<CarreiraProfissional> PutCarreiraProfissionalAsync(int id, CarreiraProfissional carreiraProfissionalAtualizada)
        {
            // Verifique se a carreira profissional atualizada não é nula
            if (carreiraProfissionalAtualizada == null)
            {
                throw new ArgumentNullException(nameof(carreiraProfissionalAtualizada), "Os dados da carreira profissional atualizada são inválidos.");
            }

            // Verifique se a carreira profissional existe com base no ID
            var existingCarreiraProfissional = await _carreiraProfissionalRepository.GetCarreiraProfissionalByIdAsync(id);

            if (existingCarreiraProfissional == null)
            {
                throw new NotFoundException($"Carreira profissional com ID {id} não encontrada.");
            }

            existingCarreiraProfissional.nomeEmpresa = carreiraProfissionalAtualizada.nomeEmpresa;
            existingCarreiraProfissional.tempoInicio = carreiraProfissionalAtualizada.tempoInicio;
            existingCarreiraProfissional.tempoFim = carreiraProfissionalAtualizada.tempoFim;
            existingCarreiraProfissional.cargo = carreiraProfissionalAtualizada.cargo;

            return existingCarreiraProfissional;

        }

          public Task DeleteCarreiraProfissionalAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CarreiraProfissional>> GetCarreiraProfissionalByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}