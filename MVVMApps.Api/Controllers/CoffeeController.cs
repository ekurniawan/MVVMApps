using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVVMApps.Api.Repository;
using MVVMApps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMApps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private ICoffeeRepository _coffeeRepo;
        public CoffeeController(ICoffeeRepository coffeeRepo)
        {
            _coffeeRepo = coffeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Coffee>> Get()
        {
            var results = await _coffeeRepo.GetAll();
            return results;
        }

        [HttpGet("{id}")]
        public async Task<Coffee> Get(string id)
        {
            var result = await _coffeeRepo.GetById(id);
            return result;
        }

        [HttpGet("ByName/{name}")]
        public async Task<IEnumerable<Coffee>> GetByName(string name)
        {
            var results = await _coffeeRepo.GetByName(name);
            return results;
        }
     }
}
