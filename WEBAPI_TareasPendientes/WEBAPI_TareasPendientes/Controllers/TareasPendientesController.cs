using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI_TareasPendientes.Models;

namespace WEBAPI_TareasPendientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasPendientesController : ControllerBase
    {
        private readonly ContextData _contextData;
        public TareasPendientesController(ContextData contextData)
        {
            _contextData = contextData;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareasPendientes>>> GetTareasPendientes()
        {
            if (_contextData.TareasPendientes == null) return NotFound();
            return await _contextData.TareasPendientes.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TareasPendientes>> GetTareaPendiente(int id)
        {
            if (_contextData.TareasPendientes == null) return NotFound();
            var tarea = await _contextData.TareasPendientes.FindAsync(id);
            if(tarea == null) return NotFound();
            return tarea;

        }
        [HttpPost]
        public async Task<ActionResult<TareasPendientes>> PostTareasPendientes(TareasPendientes tarea)
        {
            _contextData.TareasPendientes.Add(tarea);
            await _contextData.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTareasPendientes), new { id = tarea.ID }, tarea);
        }
        [HttpPut]
        public async Task<ActionResult<TareasPendientes>> PutTareasPendientes(int id, TareasPendientes tarea)
        {
            if(id!=tarea.ID) return BadRequest();
            _contextData.Entry(tarea).State = EntityState.Modified;
            try
            {
                await _contextData.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!TareaExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TareasPendientes>> DeleteTareaPendiente(int id)
        {
            if(_contextData.TareasPendientes is null) return NotFound();
            var tarea = await _contextData.TareasPendientes.FindAsync(id);
            if(tarea is null) { return NotFound(); }
            _contextData.TareasPendientes.Remove(tarea);
            await _contextData.SaveChangesAsync();
            return NoContent();
        }
        private bool TareaExists(int id)
        {
            return (_contextData.TareasPendientes?.Any(tarea=>tarea.ID == id)).GetValueOrDefault();
        }
    }
}
