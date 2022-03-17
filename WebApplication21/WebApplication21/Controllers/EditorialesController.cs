using Datos.Interface;
using Datos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        public IBaseRepository<Editoriales> _baseRepository;
        public EditorialesController(IBaseRepository<Editoriales> baseRepository)
        {
            _baseRepository = baseRepository;   
                
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> MostrarTodo() 
        {
            var mostrarTodos = await _baseRepository.MostrarTodoAsync();

            return Ok(mostrarTodos);

        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Filtrar(int id)
        {
            var data = await _baseRepository.FiltrarAsync(f => f.Codigo == id);

            return Ok(data);


        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Agregar(Editoriales entity)
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


        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Editar(int id, Editoriales editoriales)
        {
            var currentEntity = await _baseRepository.FiltrarAsync(r => r.Codigo == id);
            if (currentEntity != null)
            {
                currentEntity.Nombre = editoriales.Nombre;
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
