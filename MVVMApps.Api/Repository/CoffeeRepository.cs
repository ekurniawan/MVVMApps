using Microsoft.Extensions.Configuration;
using MVVMApps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Text;

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

        public async Task Add(Coffee coffee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"insert into Coffee(Name,Roaster,Image) 
                                values(@Name,@Roaster,@Image)";
                var param = new { Name=coffee.Name,Roaster=coffee.Roaster,Image=coffee.Image };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx) 
                { 
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public async Task AddBulk(List<Coffee> lstCoffee)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var coffee in lstCoffee)
            {
                sb.Append($"insert into Coffee(Name,Roaster,Image) values('{coffee.Name}','{coffee.Roaster}','{coffee.Image}');");
            }
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    await conn.ExecuteAsync(sb.ToString());
                }
                catch (SqlException sqlEX)
                {
                    throw new Exception(sqlEX.Message);
                }
            }
        }

        public async Task Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = "delete from Coffee where Id=@Id";
                var param = new { Id = id };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
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

        public async Task Update(string id, Coffee coffee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var result = await GetById(id);
                if (result == null)
                    throw new Exception($"Data coffee dengan id {id} tidak ditemukan");

                string strSql = @"update Coffee set Name=@Name,Roaster=@Roaster 
                                where Id=@Id";
                var param = new { Name = coffee.Name, Roaster = coffee.Roaster, Id=id };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
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
