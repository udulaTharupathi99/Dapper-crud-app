using System.Data;
using System.Data.SqlClient;
using Core.Services;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class DbService : IDbService
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
            _db = new SqlConnection(_connectionString);
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);


        public async Task<List<T>> GetAll<T>(string command, object parms) where T : class
        {
            var list = (await _db.QueryAsync<T>(command, parms)).ToList();
            return list;
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            var result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();
            return result;
        }

        public async Task<int> InsertAsync(string command, object parms)
        {
            int result;
            result = await _db.ExecuteAsync(command, parms);
            return result;
        }

        public async Task<int> UpdateAsync(string command, object parms)
        {
            int result;
            result = await _db.ExecuteAsync(command, parms);
            return result;
        }

        public T Get<T>(string command, object parms)
        {
            var result = _db.Query<T>(command, parms).SingleOrDefault();
            return result;
        }



        public Task<int> InsertQuery(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public int Insert(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public int Update(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public List<T> GetItems<T>(string command, object parms) where T : class
        {
            throw new NotImplementedException();
        }
    }

}
