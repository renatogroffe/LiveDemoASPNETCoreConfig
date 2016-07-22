using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LiveDemoASPNETCoreConfig.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        

        public HomeController(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["Config1"] =
                _configuration["Configuracoes:Configuracao1"];

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact(
            [FromServices] IOptions<Contato> contato)
        {
            Contato infoContato = contato.Value;

            ViewData["NomeContato"] = infoContato.Nome;
            ViewData["EmailContato"] = infoContato.Email;
            ViewData["TelefoneContato"] = infoContato.Telefone;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
