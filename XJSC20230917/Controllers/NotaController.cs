using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace XJSC20230917.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {

        static List<object> data = new List<object>();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> Get()
        {

            return data;
        }

        [Authorize]
        [HttpPost]

        public IActionResult Post(string nombre, int nota)
        {

            data.Add(new { nombre, nota });

            return Ok();
        }
    }
}











