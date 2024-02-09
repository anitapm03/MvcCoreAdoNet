using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VistaMascota()
        {
            List<Mascota> mascotas = new List<Mascota>();
            mascotas.Add(new Mascota("Púas", "Perro", 9));
            mascotas.Add(new Mascota("Malolo", "Pez", 3));
            mascotas.Add(new Mascota("Trufa", "Perro", 15));
            mascotas.Add(new Mascota("aaa", "aaa", 99));
            return View(mascotas);
        }
    }
}

