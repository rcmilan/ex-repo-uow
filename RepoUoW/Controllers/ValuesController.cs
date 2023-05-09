using Microsoft.AspNetCore.Mvc;
using RepoUoW.DTOs;
using RepoUoW.Entities;
using RepoUoW.Repositories;
using RepoUoW.UoW;

namespace RepoUoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ValuesController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly IUoW unitOfWork;

        public ValuesController(IRepository repository, IUoW unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("batch")]
        public async Task<IActionResult> AddBatch(IEnumerable<AddCountryInput> addCountryInputs)
        {
            foreach (var country in addCountryInputs)
            {
                var c = new Country
                {
                    Name = country.Name,
                    Cities = new List<City>()
                };

                foreach (var city in country.Cities)
                {
                    var ct = new City
                    {
                        Name = city.Name
                    };

                    c.Cities.Add(ct);
                }

                await unitOfWork.AddAsync(c);
            }

            await unitOfWork.Commit();

            return Ok();
        }

        [HttpPost("city")]
        public async Task<IActionResult> AddCity(AddCityInput addCityInput)
        {
            var country = await repository.GetAsync<Country, int>(addCityInput.CountryId);

            if (country is null) return NotFound();

            var city = new City()
            {
                Name = addCityInput.Name
            };

            country.Cities.Add(city);

            await repository.AddAsync(city);

            return Ok(country);
        }

        [HttpGet("country")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            if (id > 0)
            {
                var c = await repository.GetAsync<Country, int>(id);

                return Ok(c);
            }

            var c1 = await repository.GetAsync<Country>(c => true, c => c.Name);

            return Ok(c1);
        }
    }
}