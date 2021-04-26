using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Backend.Data;
using WebApi.Backend.models;

namespace WebApi.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        private readonly CuentaRepository _repository;

        public CuentaController(CuentaRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public object Get(String id)
        {
            // var response = await _repository.GetByCuenta(id);
            //  if (response == null) { return NotFound(); }
            //return response;
            return null;
        }

        /********************************* POST api/cuenta   1: Inserta nueva cuenta*******************+++++*/
        [HttpPost]
        public async Task Post([FromBody] Cuenta value)
        {
            await _repository.Insert(value);
        }
        /********************************************************************************/

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {

            // await _repository.DeleteByCuenta(id);
        }
    }
}
