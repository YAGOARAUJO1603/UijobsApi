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
        Task DeleteCarreiraProfissionalAsync(int id);
    }
}