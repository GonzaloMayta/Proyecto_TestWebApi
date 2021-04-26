using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using WebApi.Backend.models;
using WebApp.FrontEnd.Models;

namespace WebApp.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
/*******************************************Adicionar cuenta***/ 
        public ViewResult adicionar() => View();

        [HttpPost]
        public async Task<IActionResult> adicionar(Cuenta c)
        {
           // c.Saldo = 0;
    
            Cuenta received= new Cuenta();
            using (var httpClient = new HttpClient())
            {
                
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44394/api/cuenta", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    received = JsonConvert.DeserializeObject<Cuenta>(apiResponse);
                }
            }
            return View(received);
        }

        /**********************************************/

       

        public async Task<IActionResult>  Index()
        {

            //var httClient = new HttpClient();
           //var json= await httClient.GetStringAsync("https ://localhost:44394/api/cuenta");
           // var cuentaList = JsonConvert.DeserializeObject<List<Cuenta>>(json);
            return View();
        }

        public IActionResult Privacy()
        {


             return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
