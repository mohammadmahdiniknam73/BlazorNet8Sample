using BlazorCrudSampleSsr.Models;

namespace BlazorCrudSampleSsr.Data.Repositories
{
    public interface IContactRepository
    {
        Task InsertAsync(Contact entity);
        Task UpdateAsync(Contact entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(Contact entity);
        Task<List<Contact>> Select();
        Task<Contact> FindByIdAsync(int id);
        Task SaveChanges();
    }
}
