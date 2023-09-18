using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XJSC20230917.Models;


namespace XJSC20230917.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        static List<Matricula> data = new List<Matricula>();
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Matricula> Get()
        {
            return data;
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Matricula matricula)
        {
            data.Add(matricula);

            return Ok();
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Matricula matricula)
        {
            var existingMatricula = data.FirstOrDefault(m => m.Id == id);
            if (existingMatricula != null)
            {
                existingMatricula.Alumno = matricula.Alumno;
                existingMatricula.Grado = matricula.Grado;
                existingMatricula.Fecha = matricula.Fecha;

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}