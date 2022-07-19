

namespace Core.Services
{
    public interface IDbService
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GetAll<T>(string command, object parms) where T : class;
        Task<int> InsertAsync(string command, object parms);
        Task<int> InsertQuery(string command, object parms);
        T Insert<T>(string command, object parms);
        Task<int> UpdateAsync(string command, object parms);
        int Insert(string command, object parms);
        int Update(string command, object parms);
        T Get<T>(string command, object parms);
        List<T> GetItems<T>(string command, object parms) where T : class;
    }
}
