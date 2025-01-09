using Microsoft.AspNetCore.Mvc;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Models;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Student",
                DateOfBirth = new DateTime(1994,5,21)
            };

            return View(data);
        }
    }
}
