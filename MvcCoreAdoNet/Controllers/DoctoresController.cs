using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;
using System.Globalization;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctores();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult Index(string especialidad)
        {
            List<Doctor> doctoresEspecialidad = 
                this.repo.GetDoctoresEspecialidad(especialidad);
            return View(doctoresEspecialidad);
        }

        public IActionResult DoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            List<string> especialidades = this.repo.GetEspecialidades();
            ModelDoctores modelDoctores = new ModelDoctores();
            modelDoctores.Doctores = doctores;
            modelDoctores.Especialidades = especialidades;
            return View(modelDoctores);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctoresEspecialidad =
                this.repo.GetDoctoresEspecialidad(especialidad);
            List<string> especialidades = this.repo.GetEspecialidades();
            ModelDoctores modelDoctores = new ModelDoctores();
            modelDoctores.Doctores = doctoresEspecialidad;
            modelDoctores.Especialidades = especialidades;
            return View(modelDoctores);
        }


        public IActionResult DoctoresEspecialidadViewData()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidadViewData(string especialidad)
        {
            List<Doctor> doctoresEspecialidad =
                this.repo.GetDoctoresEspecialidad(especialidad);
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            return View(doctoresEspecialidad);
        }


    }
}
