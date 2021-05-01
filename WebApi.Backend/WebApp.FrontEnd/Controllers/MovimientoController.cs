using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.FrontEnd.Models;

namespace WebApp.FrontEnd.Controllers
{
    public class MovimientoController : Controller
    {
        private string deposito_url = "https://localhost:44320/api/Movimiento";
        private string retiro_url = "https://localhost:44320/api/Movimiento/dev";
        private string consultasaldo_url = "https://localhost:44320/api/Cuenta/";
        public IActionResult Movimientos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Movimientos(string button, Movimientos c)
        {
            switch (button)
            {
                case "Deposito":
                    Movimientos received = new Movimientos();
                    using (var client = new HttpClient())
                    {
                        var a = c.Importe;
                        StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                        using (var response = await client.PostAsync(deposito_url, content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            var result = response.StatusCode;

                            if (result.GetHashCode() == 200)
                            {
                                return RedirectToAction("Movimientos");
                            }
                        }
                    }
                    break;
                case "Retiro":
                    using (var client = new HttpClient())
                    {

                        using (var response = await client.GetAsync(consultasaldo_url + c.NroCuenta))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            double saldo = Double.Parse(apiResponse, CultureInfo.InvariantCulture);

                            if (saldo > c.Importe)
                            {

                                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                                using (var response1 = await client.PostAsync(retiro_url, content))
                                {
                                    string apiResponse1 = await response.Content.ReadAsStringAsync();
                                    var result = response.StatusCode;
                                    ViewBag.Message = "Retiro Exitoso";
                                    if (result.GetHashCode() == 200)
                                    {
                                        
                                      //  return RedirectToAction("Movimientos");
                                    }
                                }
                            }
                            else
                            {
                                ViewBag.Message = "Saldo insuficiente";
                            }

                        }
                        // return RedirectToAction("Index", "Home");
                        break;
                    }   
            }

            return View("Movimientos");
        }
    }
}
