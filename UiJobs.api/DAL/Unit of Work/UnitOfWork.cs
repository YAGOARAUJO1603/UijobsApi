using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;

namespace UijobsApi.DAL.Unit_of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
