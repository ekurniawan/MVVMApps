using Microsoft.Extensions.Configuration;
using MVVMApps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMApps.Api.Repository
{
    public class CoffeeRepository : ICoffee
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
            List<Coffee> lstCoffee = new List<Coffee>();
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Coffee 
                                  order by Name asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                await conn.OpenAsync();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                if (dr.HasRows)
                {
                    while (await dr.ReadAsync())
                    {
                        lstCoffee.Add(new Coffee
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = dr["Name"].ToString(),
                            Roaster = dr["Roaster"].ToString()
                        });
                    }
                }
                await dr.CloseAsync();
                await cmd.DisposeAsync();
                await conn.CloseAsync();

                return lstCoffee;
            }
        }

        public Task<Coffee> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, Coffee coffee)
        {
            throw new NotImplementedException();
        }
    }
}
