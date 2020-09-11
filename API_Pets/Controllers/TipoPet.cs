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
    public class TipoPet : ControllerBase
    {
        TipoPetRepository rep = new TipoPetRepository();


        // GET: api/<TipoPetController>
        [HttpGet]
        public List<TipoPet> Get()
        {
            return rep.ReadAll();
        }

        // GET api/<TipoPetController>/5
        [HttpGet("{id}")]
        public TipoPet Get(int id)
        {
            return rep.SearchForId(id);
        }

        // POST api/<TipoController>
        [HttpPost]
        public List<TipoPet> Post(TipoPet t)
        {
            return rep.Create(t);
        }

        // PUT api/<TipoController>/5
        [HttpPut("{id}")]
        public List<TipoPet> Put(int id, TipoPet t )
        {
            return rep.Update(id, t);
        }

        // DELETE api/<TipoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Delete(id);

        }
    }
}
