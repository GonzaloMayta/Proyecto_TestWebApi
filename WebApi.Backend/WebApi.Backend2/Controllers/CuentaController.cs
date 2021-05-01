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
       
        [HttpPost]
        public CuentaModels Post([FromBody] CuentaModels value)
        {
             return CuentaDomain.InsertarCuenta(value);
        }


        // GET api/Consulta saldo
        [HttpGet("{id}")]
        public float Get(String Id)
        {

            return CuentaDomain.ConsultaSaldo(Id);
        
        }



    }
}



