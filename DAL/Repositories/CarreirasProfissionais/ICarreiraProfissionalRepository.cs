using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.CarreirasProfissionais
{
    public interface ICarreiraProfissionalRepository
    {
        Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id);
        Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional AddCarreiraProfissional);
        Task DeleteCarreiraProfissionalAsync(CarreiraProfissional carreiraProfissional);
    }
}