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
        
        public Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional AddCarreiraProfissional)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCarreiraProfissionalAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CarreiraProfissional> PutCarreiraProfissionalAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}