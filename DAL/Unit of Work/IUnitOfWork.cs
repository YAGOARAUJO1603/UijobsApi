namespace UijobsApi.DAL.Unit_of_Work
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
