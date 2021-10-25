using MVVMApps.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MVVMApps.Services
{
    public static class CoffeeSQLiteService 
    {
        static SQLiteAsyncConnection db;
        private static ICoffee coffeeService;
        static async Task Init()
        {
            if (db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<Coffee>();

            coffeeService = DependencyService.Get<ICoffee>();
        }

        public static async Task AddCoffee(Coffee coffee)
        {
            await Init();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            var newCoffee = new Coffee
            {
                Name = coffee.Name,
                Roaster = coffee.Roaster,
                Image = image,
                IsSync = false
            };
            await db.InsertAsync(newCoffee);
        }

        public static async Task AddSyncData()
        {
            await Init();
            var strSql = "select * from Coffee where IsSync=false";
            var results = await db.QueryAsync<Coffee>(strSql);
            try
            {
                await coffeeService.AddBulk(results);
                foreach(var coffee in results)
                {
                    var updateSql = $"update Coffee set IsSync=true where Id={coffee.Id}";
                    await db.ExecuteAsync(updateSql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task EditCoffee(int id, Coffee coffee)
        {
            await Init();
            var result = await GetCofeeById(id);

            var strSql = $"update Coffee set Name='{coffee.Name}',Roaster='{coffee.Roaster}' where Id={id}";
            if (result != null)
                await db.ExecuteAsync(strSql);
            else
                throw new Exception($"Data coffee {id} tidak ditemukan");
        }

        public static async Task<Coffee> GetCofeeById(int id)
        {
            await Init();
            var strSql = $"select * from Coffee where Id={id}";
            var results = await db.QueryAsync<Coffee>(strSql);
            //var result = await db.Table<Coffee>().Where(c => c.Id == id).FirstOrDefaultAsync();
            return results[0];
        }

        public static async Task<IEnumerable<Coffee>> GetCoffee()
        {
            await Init();
            string strSql = "select * from Coffee order by Name asc";
            var results = await db.QueryAsync<Coffee>(strSql);
            //var results = await db.Table<Coffee>().ToListAsync();
            return results;
        }

        public static async Task RemoveCoffee(int id)
        {
            var result = await GetCofeeById(id);
            if (result != null)
                await db.DeleteAsync<Coffee>(id);
            else
                throw new Exception($"Data coffee {id} tidak ditemukan");
        }
    }
}
