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
    public class TransferenciasController : ControllerBase
    {
        private readonly CuentaRepository _repository;

        public TransferenciasController(CuentaRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        /***** POST api/    3: Realiza transferencias***/
        [HttpPost]
        public async Task Post([FromBody] Transferencia t)
        {
            await _repository.Transferencia(t);
        }
    }
}
