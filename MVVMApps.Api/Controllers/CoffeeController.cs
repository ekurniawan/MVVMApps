using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private List<Coffee> lstCoffee;
        public CoffeeController()
        {
            lstCoffee = new List<Coffee>
            {
                new Coffee{Id=1,Name="Tiwus",Roaster="Dark Roasted",Image="image"},
                new Coffee{Id=2,Name="Italian",Roaster="Dark Roasted",Image="image"}
            };
        }

        [HttpGet]
        public IEnumerable<Coffee> Get()
        {
            return lstCoffee;
        }
    }
}
