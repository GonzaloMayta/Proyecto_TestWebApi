using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Domain;
using WebApi.Models.Cuenta;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
       
    public class CuentaController : ControllerBase
    {

 

        CuentaDomain cuentaDomain = new CuentaDomain();
        /// <summary>
        /// GET: api/Usuario (retorna toda la lista)
        /// </summary>
        /// <returns></returns>
       // [ResponseType(typeof(IEnumerable<CuentaModels>))]
        public IEnumerable<CuentaModels> Get()
        {
            return cuentaDomain.ListCuentas().ToArray();
            //return users;
        }




        [HttpPost]
        public int Post([FromBody] CuentaModels value)
        {
             return CuentaDomain.InsertarCuenta(value);
        }



        /// <summary>
        /// GET: api/Usuario/5 (retorna los valores de un sólo registro según el valor id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
   /*     public IHttpActionResult Get(int id)
        {
            var usuario = cuentaDomain.ListUsers().ToArray().FirstOrDefault((p) => p.id == id);
            //var usuario = users.FirstOrDefault((p) => p.id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
   */
    }
}



/*
 // GET: api/<CuentaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CuentaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
 */