using Microsoft.Extensions.Configuration;
using MVVMApps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MVVMApps.Api.Repository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private IConfiguration _config;
        public CoffeeRepository(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public Task Add(Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coffee>> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {       
                string strSql = @"select * from Coffee 
                                  order by Name asc";
                var results = await conn.QueryAsync<Coffee>(strSql);
                return results;
            }
        }

        public async Task<Coffee> GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Coffee 
                                  where Id=@Id";

                var param = new { Id = id };
                var result = await conn.QuerySingleOrDefaultAsync<Coffee>(strSql, param);
                return result;
            }
        }

        public Task Update(string id, Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coffee>> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Coffee 
                                  where Name like @Name
                                  order by Name asc";
                var param = new { Name = $"%{name}%" };
                var results = await conn.QueryAsync<Coffee>(strSql,param);
                return results;
            }
        }
    }
}
