using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            //var c = await repository.GetAsync<Country, int>(id);
            //return Ok(c!);

            var c1 = await repository.GetAsync<Country>(c => c.Id == id, c => c.Name);
            return Ok(c1);
        }
    }
}