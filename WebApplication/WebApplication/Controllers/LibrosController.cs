using Datos.Interface;
using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class LibrosController : Controller
    {
        IBaseRepository<Libros> _baseRepository;
        public LibrosController(IBaseRepository<Libros> baseRepository)
        {
            _baseRepository = baseRepository;

        }
        public async Task<IActionResult> MostrarTodo()
        {
            string obtenerNombre = ObtenerNombre();
            _baseRepository.ConexionMapper(obtenerNombre);
            var lista = await _baseRepository.MostrarTodoAsync();
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Filtrar([FromRoute] int id)
        {
            try
            {
                string Nombre = ObtenerNombre();
                string detalle = Nombre + "/" + id;
                _baseRepository.ConexionMapper(detalle);
                var lista = await _baseRepository.FiltrarAsync();
                Libros libros = new Libros();
                foreach (Libros li in lista) libros = li;

                return View(libros);
            }
            catch (Exception ex)
            {

                throw new Exception("" + ex);
            }

        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Libros libros)
        {
            if (libros != null)
            {
                string obtenerNombre = ObtenerNombre();
                _baseRepository.ConexionMapper(obtenerNombre);
                await _baseRepository.AgregarAsync(libros);


            }

            return RedirectToAction("MostrarTodo");


        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                string obtenerNombre = ObtenerNombre();
               _baseRepository.ConexionMapper(obtenerNombre);
                await _baseRepository.EliminarAsync(Id);

                return RedirectToAction("MostrarTodo");
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
            return Ok();
        }

        public string ObtenerNombre() 
        {
            string NombreController = this.ControllerContext.RouteData.Values["Controller"].ToString();
            string NombreMetodo = this.ControllerContext.RouteData.Values["Action"].ToString();
            string Nombre = NombreController + "/" + NombreMetodo;
            return Nombre;
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id) 
        {
            Codigo = id;
            string Nombre = "Libros/Filtrar";
            string detalle = Nombre + "/" + id;
            _baseRepository.ConexionMapper(detalle);
            var lista = await _baseRepository.FiltrarAsync();
            Libros libros = new Libros();
            foreach (Libros li in lista) libros = li;
            return View(libros);
        }

        static int Codigo=0;

        public async Task<IActionResult> Editar(Libros libros)
        {
            libros.Codigo = Codigo;
            Codigo = 0;
            if (libros != null)
            {
                string obtenerNombre = ObtenerNombre();
                _baseRepository.ConexionMapper(obtenerNombre);
                await _baseRepository.EditarAsync(libros);


            }

            return RedirectToAction("MostrarTodo");
            

        }


    }
}
