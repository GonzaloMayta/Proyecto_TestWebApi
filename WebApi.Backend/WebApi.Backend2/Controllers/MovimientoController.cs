using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain;
using WebApi.Models.Movimiento;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {

        MovimientoDomain movimientoDomain = new MovimientoDomain();
        // GET: api/<MovimientoController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public float Get(MovimientoModels value)
        {
            return 0;
          //  return MovimientoDomain.Retiro(value);
        }

        // POST api/<MovimientoController>
        [HttpPost]
        //[Route("api/Movimiento/{value}")]
        public MovimientoModels Movimiento([FromBody] MovimientoModels value)
                {
                   // if (flat==0)
                    //{
                        return MovimientoDomain.Deposito(value);
                    /*}
                    else
                    {
                        return MovimientoDomain.Retiro(value);
                    }*/

            }
        
        [HttpPost("{deb}")]
       // [Route("api/retiro/{value}")]
        public MovimientoModels Retiro(String deb, [FromBody] MovimientoModels value)
        {
            return MovimientoDomain.Retiro(value);
        }


        // PUT api/<MovimientoController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] MovimientoModels value)
        {

            MovimientoModels temp = new MovimientoModels();

        }

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
