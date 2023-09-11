using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Repositories.CarreirasProfissionais
{
    public interface ICarreiraProfissionalRepository
    {
        Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id);
        Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional AddCarreiraProfissional);

        Task<CarreiraProfissional> PutCarreiraProfissionalAsync(int id, CarreiraProfissional carreiraProfissionalAtualizada);
        Task DeleteCarreiraProfissionalAsync(int id);
    }
}