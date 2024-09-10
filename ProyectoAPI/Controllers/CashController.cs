using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Models;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static readonly List<Moneda> lst = new List<Moneda>();

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(lst);
        }

        [HttpGet("{nombreMoneda}")]
        public IActionResult Get(string nombreMoneda) 
        { 
            foreach(Moneda m in lst) 
            {
                if(m.Nombre.Equals(nombreMoneda))
                    return Ok(m);
            }
            
            return NotFound("Moneda no registrada.");
        }

        [HttpPost]
        public IActionResult Save([FromBody] Moneda moneda)
        {
            if (moneda == null || string.IsNullOrEmpty(moneda.Nombre) || moneda.ValorEnPesos == 0)
            {
                return BadRequest("Datos incorrectos.");
            }
            else 
            { 
                lst.Add(moneda); 
            }
            
            return Ok("Moneda registrada correctamente.");
        }
    }
}
