using Microsoft.AspNetCore.Mvc;
using RequerimientosDto;
using RequerimientosService;

namespace ApiRestParaCorregir.Controllers
{
    [Route("requerimientos")]
    [ApiController]
    public class RequerimientosController : ControllerBase
    {
        private Service requerimientosService = new Service();

        [HttpPost]
        public IActionResult CrearRequerimiento([FromBody] RequerimientoDto requerimientoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            requerimientoDTO = requerimientosService.CrearRequerimiento(requerimientoDTO);

            return Ok(requerimientoDTO);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerRequeriminetoPorId(int id)
        {
            RequerimientoDto requerimientoDto = requerimientosService.ObtenerRequerimientoPorId(id);

            if (requerimientoDto == null)
            {
                return NotFound();
            }

            return Ok(requerimientoDto);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] RequerimientoDto requerimientoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequerimientoDto requerimientoActualizado = requerimientosService.ActualizarRequerimiento(requerimientoDto);

            if (requerimientoActualizado == null)
            {
                return NotFound();
            }

            return Ok(requerimientoDto);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            requerimientosService.EliminarRequerimiento(id);
            return Ok();
        }
    }
}
