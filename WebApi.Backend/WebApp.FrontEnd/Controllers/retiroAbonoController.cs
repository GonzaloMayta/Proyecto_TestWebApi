using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Backend.models;

namespace WebApp.FrontEnd.Controllers
{
    public class retiroAbonoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


/********************************ViewBag.Result = "Success";***********retiro cuenta***/
        public ViewResult RetiroAbonos() => View();

        [HttpPost]
        public async Task<IActionResult> RetiroAbonos(Movimiento c)
        {
            
            Movimiento received = new Movimiento();
            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44394/api/Movimiento", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    received = JsonConvert.DeserializeObject<Movimiento>(apiResponse);
                }
            }
            return View();
        }



        /**********************************************/
    }
}
