using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.FrontEnd.Models;

namespace WebApp.FrontEnd.Controllers
{
    public class CuentaController : Controller
    {

        string cuentaurl = "https://localhost:44320/api/Cuenta";
        
        /**public IActionResult Insertar()
        {
            return View("Insertar");
        }*/

        public ViewResult Insertar() => View();
        [HttpPost]
        public async Task<ActionResult> Insertar(Cuenta c)
        {
            int received =0;
            using (var client=new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync(cuentaurl, content))
                {
                    
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //received = JsonConvert.DeserializeObject<int>(apiResponse);
                }
            }
           // ModelState.AddModelError(string.Empty, "Error, contacta al administrador");

            return View(received);
        }
    }
}
