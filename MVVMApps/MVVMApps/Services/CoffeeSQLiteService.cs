using MVVMApps.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MVVMApps.Services
{
    public static class CoffeeSQLiteService 
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<Coffee>();
        }

        public static async Task AddCoffee(Coffee coffee)
        {
            await Init();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            var newCoffee = new Coffee
            {
                Name = coffee.Name,
                Roaster = coffee.Roaster,
                Image = image
            };
            await db.InsertAsync(newCoffee);
        }

        public static async Task EditCoffee(int id, Coffee coffee)
        {
            await Init();
            var result = await GetCofeeById(id);
            if (result != null)
                await db.UpdateAsync(coffee);
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
