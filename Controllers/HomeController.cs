using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020VA601_2020NR601.Data;
using P2_2020VA601_2020NR601.Models;
using System.Diagnostics;

namespace P2_2020VA601_2020NR601.Controllers
{
    public class HomeController : Controller
    {
        private readonly CovidDBContext _db;

        public HomeController(CovidDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewData["generos"] = new SelectList(listarGeneros(), "id", "genero");
            ViewData["departamentos"] = new SelectList(listarDepartamentos(), "id", "nombre");
            ViewData["casosReportados"] = listarCasos();

            return View();
        }

        public IActionResult CrearRegistro(CasosReportados casoAgregar)
        {
            _db.casosReportados.Add(casoAgregar);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

       // UTILS 
       public List<Generos> listarGeneros()
       {
            var listaGeneros = (from g in _db.generos select g).ToList();

            return listaGeneros;
       }

       public List<Departamentos> listarDepartamentos()
        {
            var listaDepartamentos = (from d in _db.departamentos select d).ToList();

            return listaDepartamentos;
        }

        public List<object> listarCasos()
        {
            var listadoCasos = (from casos in _db.casosReportados 
                                join depa in _db.departamentos on casos.departamento_id equals depa.id
                                join genero in _db.generos on casos.genero_id equals genero.id
                                select new
                                {
                                    departamento = depa.nombre,
                                    genero = genero.genero,
                                    confirmados = casos.confirmados,
                                    recuperados = casos.recuperados,
                                    fallecidos = casos.fallecidos
                                }).ToList<object>();

            return listadoCasos;
        }

    }
}