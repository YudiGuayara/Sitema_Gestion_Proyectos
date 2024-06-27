using EnvironmentalProjectManagement.Models;
using EnvironmentalProjectManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentalProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursosController : ControllerBase
    {
        private readonly RecursoService _recursoService;

        public RecursosController(RecursoService recursoService)
        {
            _recursoService = recursoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recurso>>> Get()
        {
            var recursos = await _recursoService.GetRecursosAsync();
            return Ok(recursos);
        }

        [HttpGet("{id}", Name = "GetRecurso")]
        public async Task<ActionResult<Recurso>> Get(string id)
        {
            var recurso = await _recursoService.GetRecursoByIdAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            return Ok(recurso);
        }

        [HttpPost]
        public async Task<ActionResult<Recurso>> Create(Recurso recurso)
        {
            await _recursoService.CreateRecursoAsync(recurso);

            return CreatedAtRoute("GetRecurso", new { id = recurso.Id.ToString() }, recurso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Recurso recursoIn)
        {
            var recurso = await _recursoService.GetRecursoByIdAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            await _recursoService.UpdateRecursoAsync(id, recursoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var recurso = await _recursoService.GetRecursoByIdAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            await _recursoService.DeleteRecursoAsync(recurso.Id.ToString());

            return NoContent();
        }
    }
}
