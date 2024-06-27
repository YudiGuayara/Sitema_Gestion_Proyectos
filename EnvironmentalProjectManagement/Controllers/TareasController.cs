using EnvironmentalProjectManagement.Models;
using EnvironmentalProjectManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentalProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly TareaService _tareaService;

        public TareasController(TareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> Get()
        {
            var tareas = await _tareaService.GetTareasAsync();
            return Ok(tareas);
        }

        [HttpGet("{id}", Name = "GetTarea")]
        public async Task<ActionResult<Tarea>> Get(string id)
        {
            var tarea = await _tareaService.GetTareaByIdAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult<Tarea>> Create(Tarea tarea)
        {
            await _tareaService.CreateTareaAsync(tarea);

            return CreatedAtRoute("GetTarea", new { id = tarea.Id.ToString() }, tarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Tarea tareaIn)
        {
            var tarea = await _tareaService.GetTareaByIdAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            await _tareaService.UpdateTareaAsync(id, tareaIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tarea = await _tareaService.GetTareaByIdAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            await _tareaService.DeleteTareaAsync(tarea.Id.ToString());

            return NoContent();
        }
    }
}
