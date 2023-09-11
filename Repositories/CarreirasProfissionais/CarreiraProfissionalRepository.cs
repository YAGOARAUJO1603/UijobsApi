using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;


namespace UijobsApi.Repositories.CarreirasProfissionais
{
    public class CarreiraProfissionalRepository : ICarreiraProfissionalRepository
    {

        private readonly DataContext _context;

        public CarreiraProfissionalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional NovaCarreiraProfissional)
        {
            await _context.AddAsync(NovaCarreiraProfissional);
            await _context.SaveChangesAsync();

            return NovaCarreiraProfissional;
        }




        public async Task DeleteCarreiraProfissionalAsync(int id)
        {
            var carreiraProfissionalParaExcluir = await _context.CarreiraProfissional.FirstOrDefaultAsync(CarreiraP => CarreiraP.idCarreiraProfissional == id);
            if (carreiraProfissionalParaExcluir != null)
            {
                _context.CarreiraProfissional.Remove(carreiraProfissionalParaExcluir);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id)
        {
            CarreiraProfissional carreiraProfissional = await _context.CarreiraProfissional.FirstOrDefaultAsync(CarreiraP => CarreiraP.idCarreiraProfissional == id);
            return carreiraProfissional;
        }




        public async Task<CarreiraProfissional> PutCarreiraProfissionalAsync(int id, CarreiraProfissional carreiraProfissionalAtualizada)
        {
            var existingCarreiraProfissional = await _context.CarreiraProfissional
                            .FirstOrDefaultAsync(c => c.idCarreiraProfissional == id);

            if (existingCarreiraProfissional == null)
            {
                // Crie uma mensagem de erro personalizada
                var mensagemErro = "A CarreiraProfissional com o ID fornecido não foi encontrada.";

                // Retorne uma resposta HTTP 404 (Not Found) com a mensagem no corpo da resposta
            }

            // Atualize as propriedades do objeto existente com base nas informações fornecidas na carreiraProfissionalAtualizada
            existingCarreiraProfissional.nomeEmpresa = carreiraProfissionalAtualizada.nomeEmpresa;
            existingCarreiraProfissional.tempoInicio = carreiraProfissionalAtualizada.tempoInicio;
            existingCarreiraProfissional.tempoFim = carreiraProfissionalAtualizada.tempoFim;
            existingCarreiraProfissional.cargo = carreiraProfissionalAtualizada.cargo;

            // Não esqueça de validar as outras propriedades e realizar validações necessárias

            // Salve as mudanças no banco de dados
            await _context.SaveChangesAsync();

            return existingCarreiraProfissional;
        }
    }
}