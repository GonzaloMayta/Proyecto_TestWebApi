using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Backend.Data;
using WebApi.Backend.models;

namespace WebApi.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly CuentaRepository _repository;

        public MovimientoController(CuentaRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


      /************************** POST api/Movimiento   2: Operaciones de Deposito y Retiro de una cuenta************/
        [HttpPost]
        public async Task Post([FromBody] Movimiento value)
        {
            await _repository.Movimiento(value);
        }
        /**************************************************/
        
    }
}
