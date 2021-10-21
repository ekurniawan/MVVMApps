using MVVMApps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApps.Services
{
    public interface ICoffee
    {
        Task<IEnumerable<Coffee>> GetCoffee();
        Task<Coffee> GetCofeeById(int id);
        Task AddCoffee(Coffee coffee);
        Task RemoveCoffee(int id);
        Task EditCoffee(int id, Coffee coffee);
    }
}
