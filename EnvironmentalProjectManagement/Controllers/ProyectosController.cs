using EnvironmentalProjectManagement.Models;
using EnvironmentalProjectManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentalProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly ProyectoService _proyectoService;

        public ProyectosController(ProyectoService proyectoService)
        {
            _proyectoService = proyectoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> Get()
        {
            var proyectos = await _proyectoService.GetProyectosAsync();
            return Ok(proyectos);
        }

        [HttpGet("{id}", Name = "GetProyecto")]
        public async Task<ActionResult<Proyecto>> Get(string id)
        {
            var proyecto = await _proyectoService.GetProyectoByIdAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return Ok(proyecto);
        }

        [HttpPost]
        public async Task<ActionResult<Proyecto>> Create(Proyecto proyecto)
        {
            await _proyectoService.CreateProyectoAsync(proyecto);

            return CreatedAtRoute("GetProyecto", new { id = proyecto.Id.ToString() }, proyecto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Proyecto proyectoIn)
        {
            var proyecto = await _proyectoService.GetProyectoByIdAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            await _proyectoService.UpdateProyectoAsync(id, proyectoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var proyecto = await _proyectoService.GetProyectoByIdAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            await _proyectoService.DeleteProyectoAsync(proyecto.Id.ToString());

            return NoContent();
        }
    }
}
