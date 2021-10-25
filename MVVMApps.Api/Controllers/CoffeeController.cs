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

        [HttpPost]
        public async Task<ActionResult> Insert(Coffee coffee)
        {
            try
            {
                await _coffeeRepo.Add(coffee);
                return Ok($"Data coffee {coffee.Name} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertBulk")]
        public async Task<ActionResult> InsertBulk(List<Coffee> lstCoffee)
        {
            try
            {
                await _coffeeRepo.AddBulk(lstCoffee);
                return Ok($"Data insert bulk berhasil !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Hello/{id}")]
        public string Hello(string id,string nama,string alamat)
        {
            return $"ID: {id} - {nama} dan {alamat}";
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id,Coffee coffee)
        {
            try
            {
                await _coffeeRepo.Update(id, coffee);
                return Ok($"Data coffee id {coffee.Name} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _coffeeRepo.Delete(id);
                return Ok($"Data coffee dengan id {id} berhasil didelete !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
     }
}
