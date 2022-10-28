using Microsoft.AspNetCore.Mvc;
using RepoUoW.DTOs;
using RepoUoW.Entities;
using RepoUoW.Repositories;

namespace RepoUoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ValuesController : ControllerBase
    {
        private readonly IRepository repository;

        public ValuesController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("country")]
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            if(id > 0)
            {
                var c = await repository.GetAsync<Country, int>(id);

                return Ok(c);
            }
            
            var c1 = await repository.GetAsync<Country>(c => true, c => c.Name);

            return Ok(c1);
        }

        [HttpPost("city")]
        public async Task<IActionResult> AddCity(AddCityInput addCityInput)
        {
            var country = await repository.GetAsync<Country, int>(addCityInput.CountryId);

            var city = new City()
            {
                Name = addCityInput.Name
            };

            country.Cities.Add(city);

            await repository.AddAsync(city);
            
            repository.Commit();

            return Ok(country);
        }
    }
}