using MVVMApps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMApps.Api.Repository
{
    public interface ICoffee
    {
        Task<IEnumerable<Coffee>> GetAll();
        Task<Coffee> GetById(string id);
        Task Add(Coffee coffee);
        Task Update(string id, Coffee coffee);
        Task Delete(string id);
    }
}
