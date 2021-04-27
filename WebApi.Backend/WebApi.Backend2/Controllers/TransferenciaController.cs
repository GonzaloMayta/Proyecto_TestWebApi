using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain;
using WebApi.Models.Transferencias;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        // GET: api/<TransferenciaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransferenciaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransferenciaController>
        [HttpPost]
        public TransferenciaModels Post([FromBody] TransferenciaModels t)
        {

            return TransferenciaDomain.transferecia(t);


        }

        // PUT api/<TransferenciaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransferenciaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
