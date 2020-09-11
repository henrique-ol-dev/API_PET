using API_PetShop.Domains;
using API_PetShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        RacaRepository rep = new RacaRepository();




        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return rep.ReadAll();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return rep.SearchForId(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public void Post(Raca r)
        {
            rep.Create(r);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public List<Raca> Put(int id, Raca r)
        {
            return rep.Update(id, r);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Delete(id);
        }
    }
}
