using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Services.CarreirasProfissionais
{
    public interface ICarreiraProfissionalServices
    {
        Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id);
        Task<IEnumerable<CarreiraProfissional>> GetCarreiraProfissionalByIdAsync();

        Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional novaCarreiraProfissional);

        Task<CarreiraProfissional> PutCarreiraProfissionalAsync(int id, CarreiraProfissional carreiraProfissionalAtualizada);
        Task DeleteCarreiraProfissionalAsync(int id);
    }
}