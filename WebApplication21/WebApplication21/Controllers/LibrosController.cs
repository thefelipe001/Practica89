using Datos.Interface;
using Datos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        public IBaseRepository<Libros> _baseRepository;
        public LibrosController(IBaseRepository<Libros> baseRepository)
        {
            _baseRepository = baseRepository;


        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MostrarTodo()
        {
            var mostrar = await _baseRepository.MostrarTodoAsync();

            return Ok(mostrar);

        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Filtrar(int id)
        {
            var data = await _baseRepository.FiltrarAsync(f => f.Codigo == id);

            return Ok(data);


        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Agregar(Libros entity)
        {

            await _baseRepository.AgregarAsync(entity);
            return Ok();

        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var data = await _baseRepository.FiltrarAsync(f => f.Codigo == id);

            if (data != null)
            {
                await _baseRepository.EliminarAsync(data);

            }
            else
            {
                return BadRequest();
            }

            return Ok();


        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Editar(Libros libros)
        {
            var currentEntity = await _baseRepository.FiltrarAsync(r => r.Codigo == libros.Codigo);
            if (currentEntity != null)
            {
                currentEntity.Autor = libros.Autor;
                currentEntity.Titulo = libros.Titulo;
                currentEntity.CodigoEditorial = libros.CodigoEditorial;
                await _baseRepository.EditarAsync(currentEntity);

            }
            else
            {
                return BadRequest();


            }

            return Ok();




        }
    }
}
